using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaqueteController : MonoBehaviour
{
    //Creating my Vector3
    private Vector3 myPosition;
    public float myY;
    public float velocity = 0.01f;

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

        //taking the Input
        if (Input.GetKey(KeyCode.W))
        {
            myY += velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            myY += -velocity * Time.deltaTime;
        }
        
    }
}
