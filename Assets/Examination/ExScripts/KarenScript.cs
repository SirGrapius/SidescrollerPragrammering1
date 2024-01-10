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
    public List<Sprite> KarenSprites = new List<Sprite>();
    public float RiseSpeed = 10.0f;
    //Enemy Spawning
    public float spawnRate = 10.0f;
    public GameObject[] ShmupEnemy;
    private bool canSpawn = true;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner () { 
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while (canSpawn)
        {
            yield return wait;
            int rand = Random.Range(0, ShmupEnemy.Length);
            GameObject enemyToSpawn = ShmupEnemy[rand];

            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }
    
    }

    private void Update()
    {
        int SpriteValue = 0;
       if (Health <= 160)
        {
            SpriteValue = 1;
        }
        if (Health <= 115)
        {
            SpriteValue = 2;
        }
        if (Health <= 80)
        {
            SpriteValue = 3;
        }
        if (Health <= 50)
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
        }
    }

    public void TakeDamage()
    {
        Health -= Bullet.BulletDamage;
    }
}
