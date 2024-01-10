using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShmupPlayer : MonoBehaviour
{
    public ShmupPlayerData CurrentPlayerData;
    public PlayerBulletScript PlayerBulletPrefab = null;
    public float MovementSpeedPS = 1.0f; //players movement speed per second
    public int MaxHealth = 5; //players health limit

    public TextMeshProUGUI PointText = null;
    public TextMeshProUGUI HealthText = null;

    public float Cooldown = 0.25f;
    float LastShot;

    //Movement Scripts
    void FixedUpdate()
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
        //Bullet Firing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - LastShot < Cooldown)
            {
                return;
            }
            LastShot = Time.time;
            GameObject.Instantiate(PlayerBulletPrefab, this.transform.position, PlayerBulletPrefab.transform.rotation);
        }

    }

    void Start()
    {
        CurrentPlayerData.HP = 5;
    }


    private void Update()
    {
        if(CurrentPlayerData.HP <= 0)
        {
            ShmupSceneLoader mySceneLoader = gameObject.GetComponent<ShmupSceneLoader>();
            if(mySceneLoader != null ) 
            {
                mySceneLoader.LoadScene("GameOver");
            }
        }

        HealthText.text = CurrentPlayerData.HP + "HP";
        PointText.text = CurrentPlayerData.PlayerPoints + "Points";
    }

}