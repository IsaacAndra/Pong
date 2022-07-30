using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    //creating the varable to know who's my body.
    public Rigidbody2D rb;
    private Vector2 myVelocity;
    public AudioClip boing;
    public Transform camTransform;

    public float velocity = 5f;

    public float horizontalLimit = 12f;

    // Start is called before the first frame update
    void Start()
    {
        

        int direcao = Random.Range(0, 4);

        if (direcao == 0)
        {
            myVelocity.x = velocity;
            myVelocity.y = velocity;
        }
        else if (direcao == 1)
        {
            myVelocity.x = -velocity;
            myVelocity.y = velocity;
        }
        else if (direcao == 2)
        {
            myVelocity.x = -velocity;
            myVelocity.y = -velocity;
        }
        else
        {
            myVelocity.x = velocity;
            myVelocity.y = -velocity;
        }

        //adding velocity to the left
        rb.velocity = myVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > horizontalLimit || transform.position.x < -horizontalLimit)
        {
            //Restarting my Scene
            SceneManager.LoadScene("Jogo");
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(boing, camTransform.position, 0.02f);
    }
}
