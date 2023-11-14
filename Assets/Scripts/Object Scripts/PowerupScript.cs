using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PowerupScript : MonoBehaviour
{
    public int addHealth = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var Banana = collision.gameObject.GetComponent<PhysicsCharacterController>();
        if (Banana != null )
        {
            Banana.HP += addHealth;
            addHealth = 0;
            GameObject.Destroy(gameObject);
        }
    }
}
