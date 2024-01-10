using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoliceEnemy : MonoBehaviour
{
    public int HP = 0;
    public Rigidbody2D myRigidBody = null;
    public float MovementSpeedPerSecond = 10.0f;
    public float MovementSign = 1.0f;
    public void TakeDamage(int aHPValue)
    {
        HP += aHPValue;

        if(HP < 0)
        {
            GameObject.Destroy(gameObject);
        }
    }


    void FixedUpdate()
    {
        //Copy character Velocity from rigidbody
        Vector3 characterVelocity = myRigidBody.velocity;
        //Set character XVelocity to zero
        characterVelocity.x = 0.0f;

        //Add velocity in character right direction
        characterVelocity += MovementSpeedPerSecond * transform.right.normalized * MovementSign;
        //Copy modified velocity to rigidbody
        myRigidBody.velocity = characterVelocity;
    }

}
