using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarenMissileScript : MonoBehaviour
{
    public ShmupPlayerData CurrentPlayerData = null;
    public PlayerBulletScript BulletScript = null;
    public GameObject target;
    public float Speed = 40;
    public int Health = 1;
    public int PointReward = 25;
    public int Damage = 1;
    public Rigidbody2D Enemyrb = null;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 attackPos = GetComponent<Rigidbody2D>().position;
        if (attackPos.x < Enemyrb.position.x)
        {
            attackPos.x += Speed * Time.deltaTime;
        }
        else
        if (attackPos.x > Enemyrb.position.x)
        {
            attackPos.x -= Speed * Time.deltaTime;
        }
        if (attackPos.y < Enemyrb.position.y)
        {
            attackPos.y += Speed * Time.deltaTime;
        }
        else
        if (attackPos.y > Enemyrb.position.y)
        {
            attackPos.y -= Speed * Time.deltaTime;
        }
        GetComponent<Rigidbody2D>().position = attackPos;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ShmupPlayer playerComp = collision.gameObject.GetComponent<ShmupPlayer>();
        if (playerComp != null)
        {
            CurrentPlayerData.HP -= Damage;
        }
    }

    public void TakeDamage()
    {
            GameObject.Destroy(gameObject);
            CurrentPlayerData.PlayerPoints += PointReward;
    }
}
