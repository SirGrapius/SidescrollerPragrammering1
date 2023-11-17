using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public bool IsPlayer = false;

    public int DamageValue = -1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsPlayer)
        {
            var PoliceEnemy = collision.gameObject.GetComponent<PoliceEnemy>();
            if (PoliceEnemy != null)
            {
                PoliceEnemy.TakeDamage(DamageValue);
            }
        }
        else
        {
            var PlayerScript = collision.gameObject.GetComponent<PhysicsCharacterController>();
            if (PlayerScript != null)
            {
                PlayerScript.TakeDamage(DamageValue);
            }
        }
    }
}
