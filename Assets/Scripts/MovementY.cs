using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementY : MonoBehaviour
{
    public float movsize = 3f;
    //[Range(0f,26f)]
    public KeyCode mykey;

     void Update()
    {
        //condition
        if (Input.GetKeyDown(mykey))
        {
            //Moving the player
            transform.position += new Vector3(-movsize, 0, 0);
        }
    }
}
