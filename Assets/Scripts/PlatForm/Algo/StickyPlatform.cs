using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private Rigidbody rb;
    CharacterController cc;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            cc = other.GetComponent<CharacterController>();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            cc.Move(rb.velocity * Time.deltaTime);
        }
    }
    
}

