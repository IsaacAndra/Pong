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

    public bool player1;

    //variable to verify if it should be Controlled by IA
    public bool automatic = false;

    //taking ball position
    public Transform ballTransform;
    

    // Start is called before the first frame update
    void Start()
    {
        myPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        //myY to the "Y" of my position
        myPosition.y = myY;

        //modify the paddle position
        transform.position = myPosition;

        //velocity mutiple by deltatime
        float deltaVelocity = velocity * Time.deltaTime;

        if (!automatic)
        {

            //verifing if is player 1
            if (player1)
            {
                //taking the Input
                if (Input.GetKey(KeyCode.W))
                {
                    myY += deltaVelocity;
                }
                //taking Input
                if (Input.GetKey(KeyCode.S))
                {
                    myY += -deltaVelocity;
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    myY += deltaVelocity;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    myY += -deltaVelocity;
                }

                //Automatic alternated player
                if(Input.GetKey(KeyCode.Return))
                {
                    automatic = true;
                }
            }
        }
        else
        {
            //Manual alternated player
            if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                automatic = false;
            }


            myY = Mathf.Lerp(myY, ballTransform.position.y, 0.1f);
        }

        //preventing the player from going over the limit
        if (myY < -myLimit)
        {
            myY = -myLimit;
        }
        if (myY > myLimit)
        {
            myY = myLimit;
        }
    }
}
