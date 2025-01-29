using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform cameraMain;
    [SerializeField] private Transform child;
    public GameObject PlayerUIPanel;

    [Header("Movement Parameters")]
    [SerializeField] private float playerSpeed;
    [SerializeField] private float backwardSpeedMultiplier = 0.75f; 
    [SerializeField] private float jumpHeight = 1.1f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float rotationSpeed = 4f;

    [Header("Animation Parameters")]
    [SerializeField] private Animator animator;
    private int isWalkingHash;
    private int isIdleHash;
    private int isJumpingHash;
    private int isBackwardHash;
    private bool isJumping;

    private Player playerInput;
    private Vector2 movementInput;
    private Vector3 playerVelocity;
    private Vector3 smoothPlayerVelocity;
    private bool groundedPlayer;

    [SerializeField] private float dashDistance = 5f;
    [SerializeField] private float dashDuration = 0.5f;
    private bool isDashing = false;

    private void Awake()
    {
        PlayerUIPanel.SetActive(true);

        playerInput = new Player();
        playerInput.Enable();

        isWalkingHash = Animator.StringToHash("isWalking");
        isIdleHash = Animator.StringToHash("isIdle");
        isJumpingHash = Animator.StringToHash("isJumping");
        isBackwardHash = Animator.StringToHash("isBackward"); 
    }

    private void OnEnable() => playerInput.Enable();
    private void OnDisable() => playerInput.Disable();

    private void Update()
    {
        HandleMovementInput();
        HandleJumpInput();
        HandleGravity();
        HandleAnimation();
        HandleCameraRotation();
    }

    public void Move(Vector3 moveDirection)
    {
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void HandleMovementInput()
    {
        groundedPlayer = controller.isGrounded;

        movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        Vector3 move = (cameraMain.forward * movementInput.y + cameraMain.right * movementInput.x);
        move.y = 0f;

        float currentSpeed = playerSpeed;

        // Check for backward movement
        if (movementInput.y < 0)
        {
            currentSpeed *= backwardSpeedMultiplier;
            animator.SetBool(isBackwardHash, true);
        }
        else
        {
            animator.SetBool(isBackwardHash, false);
        }

        if (movementInput == Vector2.zero)
        {
            smoothPlayerVelocity = Vector3.zero;
        }

        smoothPlayerVelocity = move.normalized * currentSpeed;

        controller.Move(smoothPlayerVelocity * Time.deltaTime);
    }

    private void HandleJumpInput()
    {
        float moveMagnitude = new Vector2(movementInput.x, movementInput.y).magnitude;

        if (groundedPlayer && playerInput.PlayerMain.Jump.triggered)
        {
            isJumping = true;
            // Trigger regular jump animation
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            animator.SetBool(isJumpingHash, true);
        }
    }

    private void HandleGravity()
    {
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void HandleAnimation()
    {
        float moveMagnitude = new Vector2(movementInput.x, movementInput.y).magnitude;
        animator.SetBool(isBackwardHash, movementInput.y < 0);
        animator.SetBool(isWalkingHash, moveMagnitude > 0 && !isJumping && movementInput.y >= 0);
        animator.SetBool(isIdleHash, moveMagnitude == 0 && !isJumping);
        animator.SetBool(isJumpingHash, isJumping);
        isJumping = false;
    }


    private void HandleCameraRotation()
    {
        if (movementInput != Vector2.zero)
        {
            Quaternion rotation = Quaternion.Euler(new Vector3(child.localEulerAngles.x, cameraMain.localEulerAngles.y, child.localEulerAngles.z));
            child.rotation = Quaternion.Lerp(child.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
    }
}
