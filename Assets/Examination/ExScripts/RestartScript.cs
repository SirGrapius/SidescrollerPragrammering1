using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    public ShmupSceneLoader mySceneLoaderEX = null;
    public string NextScene = "ShmupLevel1";
    public void Update()
    {
        ShmupSceneLoader mySceneLoader = gameObject.GetComponent<ShmupSceneLoader>();
        if (mySceneLoader != null)
        {
            mySceneLoaderEX.LoadScene(NextScene);
        }
    }
}
