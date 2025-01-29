using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponAttributes : MonoBehaviour
{
    public EnemyAttributes atm;
    public int dmg;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<AttributesManager>().TakeDamage(atm.attack);
        }
    }
}