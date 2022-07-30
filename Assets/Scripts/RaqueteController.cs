using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaqueteController : MonoBehaviour
{
    //Creating my Vector3
    private Vector3 myPosition;
    private float myY;
    public float velocity = 0.01f;
    public float myLimit = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        myPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        //myY to the y of my position
        myPosition.y = myY;

        //modify the paddle position
        transform.position = myPosition;

        //taking the Input AND increase the value of Y only if it less then myLimit
        if (Input.GetKey(KeyCode.W) && myY < myLimit)
        {
            myY += velocity * Time.deltaTime;         
        }
        //taking Input AND decrease the value of the Y only if it greater then myLimit
        if (Input.GetKey(KeyCode.S) && myY > -myLimit)
        {                     
            myY += -velocity * Time.deltaTime;
        }
        
    }
}
