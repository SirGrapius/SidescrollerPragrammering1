using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] int testInt = 5;

    public float MovementSpeedPerSecond = 10.0f;
    public int MovementSign = 1;

    public Rigidbody2D myRigidBody = null;

    private void FixedUpdate()
    {
        Vector3 characterVelocity = myRigidBody.velocity;
        characterVelocity.x = 0;

        characterVelocity += MovementSign * MovementSpeedPerSecond * transform.right.normalized;

        myRigidBody.velocity = characterVelocity;

        Debug.Log("Velocity is: " + myRigidBody.velocity);
    }
}
