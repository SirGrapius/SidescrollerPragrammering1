using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float Radius = 1;
    public float spawnRate = 10f;
    public GameObject ShmupEnemy;
    public bool canSpawn = false;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        canSpawn = true;
        while (canSpawn)
        {
            yield return wait;
            Vector3 randomPos = Random.insideUnitCircle * Radius;

            Instantiate(ShmupEnemy, randomPos, Quaternion.identity);
            
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(this.transform.position, Radius);
    }


}
