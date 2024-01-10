using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EXEnemyScript : MonoBehaviour
{
    public ShmupPlayerData CurrentPlayerData = null;
    public PlayerBulletScript Bullet = null;
    public GameObject OffScreenChecker = null;
    public float MovementSpeed = 10.0f;
    public int EnemyDamage = 1;
    public int EnemyHealth = 1;
    public int EnemyPointGain = 50;

    private void FixedUpdate()
    {
        Vector3 enemyPos = GetComponent<Rigidbody2D>().position;
        enemyPos.x -= MovementSpeed * Time.deltaTime;
        GetComponent<Rigidbody2D>().position = enemyPos;
        if (OffScreenChecker.transform.position.x > transform.position.x)
        {
            CurrentPlayerData.HP -= 1;
            GameObject.Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ShmupPlayer playerComp = collision.gameObject.GetComponent<ShmupPlayer>();
        if (playerComp != null)
        {
            CurrentPlayerData.HP -= EnemyDamage;
        }
    }

    public void TakeDamage()
    {
        EnemyHealth -= Bullet.BulletDamage;
        if (EnemyHealth < 0) 
        {
            GameObject.Destroy(gameObject);
            CurrentPlayerData.PlayerPoints += EnemyPointGain;
        }
    }
}
