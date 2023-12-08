using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShmupPlayer : MonoBehaviour
{
    public Rigidbody2D myRigidBody2d = null; //reference to rigidbody
    public float MovementSpeedPS = 1.0f; //players movement speed per second
    public int MaxHealth = 5; //players health limit
    public int CurrentHealth; //players current health
    public HealthBarScript HealthBar; //reference to healthbar script
    public SceneLoader SceneLoader; //reference to sceneloader script
    public string NextScene = "GameOver";

    //Movement Scripts
    private void Update()
    {
        //Go up
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 characterPosition = transform.position;
            characterPosition.y += MovementSpeedPS * Time.deltaTime;
            transform.position = characterPosition;
        }
        //Go down
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 characterPosition = transform.position;
            characterPosition.y -= MovementSpeedPS * Time.deltaTime;
            transform.position = characterPosition;
        }
        //Go left
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 characterPosition = transform.position;
            characterPosition.x -= MovementSpeedPS * Time.deltaTime;
            transform.position = characterPosition;
        }
        //Go right
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 characterPosition = transform.position;
            characterPosition.x += MovementSpeedPS * Time.deltaTime;
            transform.position = characterPosition;
        }
        //Damage test
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }

    }

    //Set base health
    void Start()
    {
        CurrentHealth = MaxHealth;
        HealthBar.SetMaxHealth(MaxHealth);
    }

    //Taking damage
    void TakeDamage(int Damage)
    {
        CurrentHealth -= Damage;
        HealthBar.SetHealth(CurrentHealth);
    }

    private void Reset()
    {
        if (CurrentHealth >= 0)
        {
            SceneLoader.LoadScene(NextScene);
        }
    }
}
