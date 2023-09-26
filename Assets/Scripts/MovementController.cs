using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    
    void Start()
    {
        
    }

    public float GravityPerSecond = 160.0f; //falling speed
    public float GroundLevel = 0.0f; //Ground Value
    public float MovementSpeedPerSecond = 10.0f; //Movement Speed


    void Update()
    {
        //Gravity
        Vector3 gravityPosition = transform.position; //copy char position
        gravityPosition.y -= GravityPerSecond * Time.deltaTime; //subtract GravityDeltaTime
        if (gravityPosition.y < GroundLevel) { gravityPosition.y = GroundLevel; } //Set character to ground level
        transform.position = gravityPosition; // Assaign new pos to transform

        //Up
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 characterPosition = transform.position; //copy char position
            characterPosition.y += MovementSpeedPerSecond * Time.deltaTime; //add movementspeed * time per frame
            transform.position = characterPosition; //assign new position
        }
        //Left
        if(Input.GetKey(KeyCode.A))
        {
            Vector3 characterPosition = transform.position; //copy char position
            characterPosition.x -= MovementSpeedPerSecond * Time.deltaTime; //add movementspeed * time per frame
            transform.position = characterPosition; //assign new position
        }
        //Down
        if(Input.GetKey(KeyCode.S))
        {
            Vector3 characterPosition = transform.position; //copy char position
            characterPosition.y -= MovementSpeedPerSecond * Time.deltaTime; //add movementspeed * time per frame
            transform.position = characterPosition; //assign new position
        }
        //Right
        if(Input.GetKey(KeyCode.D))
        {
            Vector3 characterPosition = transform.position; //copy char position
            characterPosition.x += MovementSpeedPerSecond * Time.deltaTime; //add movementspeed * time per frame
            transform.position = characterPosition; //assign new position
        }
    }
}
