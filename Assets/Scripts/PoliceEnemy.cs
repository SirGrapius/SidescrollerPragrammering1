using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoliceEnemy : MonoBehaviour
{
    public int HP = 0;
    public void TakeDamage(int aHPValue)
    {
        HP += aHPValue;

        if(HP < 0)
        {
            GameObject.Destroy(gameObject);
        }
    }

    //Reference to phsyics system component
    public Rigidbody2D myRigidBody = null;

    public float MovementSpeedPerSecond = 10.0f;

    void FixedUpdate()
    {
        //Copy character Velocity from rigidbody
        Vector3 characterVelocity = myRigidBody.velocity;
        //Set character XVelocity to zero
        characterVelocity.x = 0.0f;

        //Add velocity in character right direction
        characterVelocity += MovementSpeedPerSecond * transform.right.normalized;
        //Copy modified velocity to rigidbody
        myRigidBody.velocity = characterVelocity;
    }
}
