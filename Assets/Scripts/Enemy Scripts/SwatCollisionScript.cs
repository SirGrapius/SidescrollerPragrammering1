using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwatCollisionScript : MonoBehaviour
{
    public SwatEnemyScript myEnemyScript = null;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 enemyscale = myEnemyScript.transform.localScale;
        enemyscale.x = -enemyscale.x;
        myEnemyScript.transform.localScale = enemyscale;
        myEnemyScript.MovementSign *= -1;
    }
}
