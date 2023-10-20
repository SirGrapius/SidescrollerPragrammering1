using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PhysicsCharacterController myCharacterController = null;
    private void OnCollisionEnter(Collision collision)
    {
        myCharacterController.JumpingState = CharacterState.Grounded;
    }
}
