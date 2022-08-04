using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    //creating the varable to know who's my body.
    public Rigidbody2D rb;
    public AudioClip boing;
    public Transform camTransform;
    private Vector2 myVelocity;

    public float velocity = 5f;
    public float horizontalLimit = 12f;

    public float delay = 1f;
    public bool gameStarted = false;

    // Update is called once per frame
    void Update()
    {
        DalayTime();
        LimitPosition();
    }

    //Function responsible for delaying the startgame and the random direction of the ball.
    private void DalayTime()
    {
        //Decreasing delay's value
        delay -= Time.deltaTime;

        //Verifing if delay is in 0
        if (delay <= 0 && gameStarted == false)
        {
            Debug.Log("Cheguei no 0");

            gameStarted = true;

            //Game Inicialization/Random Direction
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
    }

    //Function responsible for the horizontal limit of the ball
    private void LimitPosition()
    {
        if (transform.position.x > horizontalLimit || transform.position.x < -horizontalLimit)
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
