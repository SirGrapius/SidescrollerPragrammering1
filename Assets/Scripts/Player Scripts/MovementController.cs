using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterState
{
    Grounded = 0,
    Airborne = 1,
    Jumping = 2,
    Total
}
public class MovementController : MonoBehaviour
{

    public CharacterState JumpingState = CharacterState.Airborne;

    //Gravity
    public float GravityPerSecond = 160.0f; //falling speed
    public float GroundLevel = 0.0f; //Ground
    //Jump
    public float JumpSpeedFactor = 3.0f;
    public float JumpMaxHeight = 150.0f;
    private float JumpHeightDelta = 0.0f;
    //Movement
    public float MovementSpeedPerSecond = 10.0f; //Movement Speed


    void Update()
    {
        //Gravity
        Vector3 gravityPosition = transform.position; //copy char position
        gravityPosition.y -= GravityPerSecond * Time.deltaTime; //subtract GravityDeltaTime
        if (gravityPosition.y < GroundLevel) { gravityPosition.y = GroundLevel; } //Set character to ground level
        transform.position = gravityPosition; // Assaign new pos to transform

        //1. Check if player is on the ground so they can jump
        if (transform.position.y <= GroundLevel)
        {
            Vector3 characterPosition = transform.position;
            characterPosition.y = GroundLevel;
            transform.position = characterPosition;
            JumpingState = CharacterState.Grounded;
        }
        //Up
        //2. Check if player presses the jump button
        if (Input.GetKey(KeyCode.W) && JumpingState == CharacterState.Grounded)
        {
            JumpingState = CharacterState.Jumping; //Set character to jumping
            JumpHeightDelta = 0.0f; //Restart counting jumpdistance
        }
        //3. Do the jump math
        if (JumpingState == CharacterState.Jumping)
        {
            Vector3 characterPosition = transform.position;
            float totalJumpMovementThisFrame = MovementSpeedPerSecond * JumpSpeedFactor * Time.deltaTime;
            characterPosition.y += totalJumpMovementThisFrame;
            transform.position = characterPosition;
            JumpHeightDelta += totalJumpMovementThisFrame;
            if (JumpHeightDelta >= JumpMaxHeight)
            {
                JumpingState = CharacterState.Airborne;
                JumpHeightDelta = 0.0f;
            }
        }

        //Left
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 characterPosition = transform.position; //copy char position
            characterPosition.x -= MovementSpeedPerSecond * Time.deltaTime; //add movementspeed * time per frame
            transform.position = characterPosition; //assign new position
        }

        //Down
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 characterPosition = transform.position; //copy char position
            characterPosition.y -= MovementSpeedPerSecond * Time.deltaTime; //add movementspeed * time per frame
            transform.position = characterPosition; //assign new position
        }

        //Right
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 characterPosition = transform.position; //copy char position
            characterPosition.x += MovementSpeedPerSecond * Time.deltaTime; //add movementspeed * time per frame
            transform.position = characterPosition; //assign new position
        }
    }
}