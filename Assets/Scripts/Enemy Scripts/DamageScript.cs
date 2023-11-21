using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public bool IsPlayer = false;

    public int DamageValue = -1;
    public bool DealtDamageLastFrame = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(DealtDamageLastFrame == true)
        {
            DealtDamageLastFrame = false;
            return;
        }
        if (IsPlayer)
        {
            var PoliceEnemy = collision.gameObject.GetComponent<PoliceEnemy>();
            if (PoliceEnemy != null)
            {
                PoliceEnemy.TakeDamage(DamageValue);
                DealtDamageLastFrame = true;
            }

            var SwatOfficerEnemy = collision.gameObject.GetComponent<SwatEnemyScript>();
            if (SwatOfficerEnemy != null)
            {
                SwatOfficerEnemy.TakeDamage(DamageValue);
                DealtDamageLastFrame = true;
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
