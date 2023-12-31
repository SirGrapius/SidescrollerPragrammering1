using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhysicsCharacterController : MonoBehaviour
{
    public Animator myAnimator = null;

    public PlayerData Savefile;
    public GameObject collision = null;
    public SpriteRenderer mySpriteRender = null;
    public List<Sprite> CharacterSprite = new List<Sprite>();
    public int HP = 1;
    //reference to rigid body on the same object
    public Rigidbody2D myRigidBody = null;
    public GameObject myCollisionCheckObject;

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
        if(HP <= 0)
        {
            SceneLoader mySceneLoader = gameObject.GetComponent<SceneLoader>();
            if(mySceneLoader != null )
            {
                mySceneLoader.LoadScene("GameOver");
            }
        }
        int hpCopy = HP - 1;
        if (hpCopy < 0)
        {
            hpCopy = 0;
        }
        if (hpCopy >= CharacterSprite.Count)
        {
            hpCopy = CharacterSprite.Count - 1;
        }
        if (mySpriteRender.sprite = CharacterSprite[hpCopy])
        {
            mySpriteRender.sprite = CharacterSprite[hpCopy];
            Destroy(GetComponent<PolygonCollider2D>());
            var polygonCollider = gameObject.AddComponent<PolygonCollider2D>();
            myCollisionCheckObject.transform.position = polygonCollider.ClosestPoint(myCollisionCheckObject.transform.position);
        }

    }


    void FixedUpdate()
    {
        myAnimator.SetBool("IsJumping", false);
        if (Input.GetKeyDown(KeyCode.Space) && JumpingState == CharacterState.Grounded)
        {
            myAnimator.SetBool("IsJumping", true);
            JumpingState = CharacterState.Jumping; //Set character to jumping
            JumpHeightDelta = 0.0f; //Restart Counting Jumpdistance
            JumpStartingY = transform.position.y;
        }

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
        myAnimator.SetBool("IsWalking", false);
        //Left
        if (Input.GetKey(KeyCode.A))
        {
            characterVelocity.x -= MovementSpeedPerSecond;
            myAnimator.SetBool("IsWalking", true);
            Vector3 playerScale = transform.localScale;
            playerScale.x = -(Mathf.Abs(playerScale.x));
            transform.localScale = playerScale;
        }

        //Right
        if (Input.GetKey(KeyCode.D))
        {
            characterVelocity.x += MovementSpeedPerSecond;
            myAnimator.SetBool("IsWalking", true);
            Vector3 playerScale = transform.localScale;
            playerScale.x = Mathf.Abs(playerScale.x);
            transform.localScale = playerScale;
        }
        myRigidBody.velocity = characterVelocity;
    }

    public void TakeDamage(int aHPValue)
    {
        HP += aHPValue;
    }
}