using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhysicsCharacterController : MonoBehaviour
{
    //reference to rigid body on the same object
    public Rigidbody2D myRigidBody = null;

    public CharacterState JumpingState = CharacterState.Airborne;
    //is our character on the ground or in the air?

    //Gravity
    public float GravityPerSecond = 160.0f; //falling speed
    public float GroundLevel = 0.0f; //Ground

    //Jump
    public float JumpSpeedFactor = 3.0f;
    public float JumpMaxHeight = 150.0f;
    [SerializeField]
    private float JumpHeightDelta = 0.0f;
    private float JumpStartingY = 0.0f;

    //Movement
    public float MovementSpeedPerSecond = 10.0f; //Movement Speed


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && JumpingState == CharacterState.Grounded)
        {
            JumpingState = CharacterState.Jumping; //Set character to jumping
            JumpHeightDelta = 0.0f; //Restart Counting Jumpdistance
            JumpStartingY = transform.position.y;
        }
    }


    void FixedUpdate()
    {
        Vector3 characterVelocity = myRigidBody.velocity;
        characterVelocity.x = 0.0f;

        if (JumpingState == CharacterState.Jumping)
        {

            float totalJumpMovementThisFrame = MovementSpeedPerSecond * JumpSpeedFactor;
            characterVelocity.y = totalJumpMovementThisFrame;

            JumpHeightDelta += totalJumpMovementThisFrame * Time.deltaTime;

            if (JumpHeightDelta >= JumpMaxHeight)
            {
                JumpingState = CharacterState.Airborne;
                JumpHeightDelta = 0.0f;
                characterVelocity.y = 0.0f;
            }
        }

        //Left
        if (Input.GetKey(KeyCode.A))
        {
            characterVelocity.x -= MovementSpeedPerSecond;
           
        }

        //Right
        if (Input.GetKey(KeyCode.D))
        {
            characterVelocity.x += MovementSpeedPerSecond;
        }
        myRigidBody.velocity = characterVelocity;
    }
}