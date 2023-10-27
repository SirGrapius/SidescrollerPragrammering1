using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
//TODO Optional: rename to CollisionScript
public class PartScript : MonoBehaviour
{

    //x = width, y = height
    public Vector2 Dimensions = new Vector2(16.0f, 16.0f);
    //position of the lower left corner
    public Vector2 LowerLeftCorner = new Vector2();

    void Update()
    {
        //update the position of the lower left corner every frame
        LowerLeftCorner = new Vector2(transform.position.x - (Dimensions.x * 0.5f),
            transform.position.y - (Dimensions.y * 0.5f));
    }


    public static bool CheckCollision(PartScript aObject1, PartScript aObject2)
    {
        //is object1 left corner smaller than object2 right corner?
        if(aObject1.LowerLeftCorner.x < aObject2.LowerLeftCorner.x+ aObject2.Dimensions.x &&
            //is object1 right corner bigger than object2 left corner?
            aObject1.LowerLeftCorner.x + aObject1.Dimensions.x > aObject2.LowerLeftCorner.x &&
            //is object1 bottom less tall than object2 top?
            aObject1.LowerLeftCorner.y < aObject2.LowerLeftCorner.y + aObject2.Dimensions.y &&
            //is object1 top taller than object2 bottom?
            aObject1.LowerLeftCorner.y + aObject1.Dimensions.y > aObject2.LowerLeftCorner.y)
        {
            return true;
        }
        return false;
    }


  
}
