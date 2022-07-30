using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //creating the varable to know who's my body.
    public Rigidbody2D rb;
    private Vector2 myVelocity;

    public float velocity = 5f;

    // Start is called before the first frame update
    void Start()
    {
        myVelocity.x = -velocity;
        //adding velocity to the left
        rb.velocity = myVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
