using UnityEngine;

public class DodgeRoll : MonoBehaviour
{
    public AttributesManager Atm;
    private Player playerInput;
    private PlayerController playerController;
    private Animator Anim;

    public float DelayBeforeInvinsible = 0.2f;
    public float InvinsibleDuration = 0.5f;
    public float DodgeCooldown = 1;
    public float PushAmt = 3;

    private float currentCooldown;

    private void Start()
    {
        Atm = GetComponent<AttributesManager>();
        playerController = GetComponentInParent<PlayerController>();
        Anim = GetComponent<Animator>();
        playerInput = new Player();
        playerInput.Enable();
    }

    private void Update()
    {
        if (currentCooldown <= 0 && playerInput.PlayerMain.Dodge.triggered)
        {
            Dodge();
        }
        else
        {
            currentCooldown -= Time.deltaTime;
        }
    }

    private void Dodge()
    {
        currentCooldown = DodgeCooldown;
        Atm.Invinsible(DelayBeforeInvinsible, InvinsibleDuration);

        // Get the camera's forward direction
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0; // Ensure the direction is horizontal

        // Apply the dodge direction relative to the camera
        Vector3 dodgeDirection = cameraForward.normalized * PushAmt;

        // Assuming playerController is a CharacterController
        playerController.Move(dodgeDirection * Time.deltaTime);

        Anim.SetTrigger("Roll");
    }
}
