using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScripy : MonoBehaviour
{
    public ShmupSceneLoader mySceneLoaderEX = null;
    public GameObject OffScreenChecker = null;
    public string NextScene = "ShmupLevel2";
    public float MovementSpeed = 10.0f;

    private void FixedUpdate()
    {
        Vector3 enemyPos = GetComponent<Rigidbody2D>().position;
        enemyPos.x -= MovementSpeed * Time.deltaTime;
        GetComponent<Rigidbody2D>().position = enemyPos;
        if (OffScreenChecker.transform.position.x > transform.position.x)
        {
            ShmupSceneLoader mySceneLoader = gameObject.GetComponent<ShmupSceneLoader>();
            if (mySceneLoader != null)
            {
                mySceneLoaderEX.LoadScene(NextScene);
            }
        }
    }
}
