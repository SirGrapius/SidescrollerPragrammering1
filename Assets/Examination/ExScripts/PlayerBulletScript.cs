using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{
    public GameObject OffScreenChecker = null;
    public float MovementSpeed = 1;
    public int BulletDamage = 1;

    private void Update()
    {
        Vector3 bulletPos = GetComponent<Rigidbody2D>().position;
        bulletPos.x += MovementSpeed * Time.deltaTime;
        GetComponent<Rigidbody2D>().position = bulletPos;
        if (OffScreenChecker.transform.position.x < transform.position.x)
        {
            GameObject.Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EXEnemyScript enemyComp = collision.gameObject.GetComponent<EXEnemyScript>();
        if (enemyComp != null)
        {
            enemyComp.TakeDamage();
            GameObject.Destroy(gameObject);
        }
        KarenScript bossComp = collision.gameObject.GetComponent<KarenScript>();
        if (bossComp != null)
        {
            bossComp.TakeDamage();
            GameObject.Destroy(gameObject);
        }
    }
}
