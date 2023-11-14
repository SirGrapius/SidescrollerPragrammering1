using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElmoScript : MonoBehaviour
{
    public SceneLoader mySceneLoader = null;
    public string NextScene = "MainMenu";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var WinBlockElmo = collision.gameObject.GetComponent<PhysicsCharacterController>();
        if (WinBlockElmo != null)
        {
            mySceneLoader.LoadScene(NextScene);
        }
    }
}
