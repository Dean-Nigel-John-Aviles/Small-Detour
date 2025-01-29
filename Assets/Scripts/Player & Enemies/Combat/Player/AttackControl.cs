using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackControl : MonoBehaviour
{
    private Animator anim;
    private Player playerInput;
    private PlayerController playerController;
    private bool isAttacking;

    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerInput = new Player();
        playerInput.Enable();
        playerController = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInput.PlayerMain.Attack.triggered)
        {
            float startTime = Time.realtimeSinceStartup;
            anim.SetTrigger("Attack");
            float endTime = Time.realtimeSinceStartup;
            float exTime = (endTime - startTime) * 1000f;
            Debug.Log("Attacking" + exTime);
        }
    }
}
