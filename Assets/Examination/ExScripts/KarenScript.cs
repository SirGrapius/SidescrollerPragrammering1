using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KarenScript : MonoBehaviour
{
    public int Health = 200;
    public int KarenPointGain = 9999;
    public ShmupPlayerData CurrentPlayerData = null;
    public PlayerBulletScript Bullet = null;
    public SpriteRenderer mySpriteRenderer = null;
    public ShmupSceneLoader mySceneLoaderEX = null;
    public string NextScene = "ShmupWinFinal";
    public List<Sprite> KarenSprites = new List<Sprite>();
    public float RiseSpeed = 10.0f;


    void Start()
    {

    }



    private void Update()
    {
        int SpriteValue = 0;
       if (Health <= 240)
        {
            SpriteValue = 1;
        }
        if (Health <= 190)
        {
            SpriteValue = 2;
        }
        if (Health <= 130)
        {
            SpriteValue = 3;
        }
        if (Health <= 80)
        {
            SpriteValue = 4;
        }
        if (Health <= 0)
        {
            SpriteValue = 5;
        }
        if (mySpriteRenderer.sprite = KarenSprites[SpriteValue]) 
        {
            mySpriteRenderer.sprite = KarenSprites[SpriteValue];
        }
    }

    private void FixedUpdate()
    {
        Vector3 bossPos = GetComponent<Rigidbody2D>().position;
        bossPos.y += RiseSpeed * Time.deltaTime;
        GetComponent<Rigidbody2D>().position = bossPos;
        if (bossPos.y >= -35)
        {
            RiseSpeed = 0;
        }
        if (Health <= 0)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            if (GetComponent<Rigidbody2D>().position.y <= -1000);
            {
                ShmupSceneLoader mySceneLoader = gameObject.GetComponent<ShmupSceneLoader>();
                if (mySceneLoader != null)
                {
                    mySceneLoaderEX.LoadScene(NextScene);
                }
            }
        }
    }

    public void TakeDamage()
    {
        Health -= Bullet.BulletDamage;
    }
}
