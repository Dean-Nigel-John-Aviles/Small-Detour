using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttributes : MonoBehaviour
{
    public AttributesManager atm;
    public float attackCooldown = 0f;
    private float lastAttackTime;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") && Time.time - lastAttackTime >= attackCooldown)
        {
            other.GetComponent<EnemyAttributes>().TakeDamage(atm.attack);
            lastAttackTime = Time.time;
        }
    }
}
