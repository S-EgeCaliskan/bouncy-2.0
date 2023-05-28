using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float bounceForce = 10;
    private GameManager gameManager;
    private float yBoundary = 30;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.gameIsRunning == false)
        {
            rb.Sleep(); //if the game is currently not running, the player stands still.
        }
        if (gameManager.gameIsRunning)
        {
            //Spacebar to bounce
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
                rb.velocity = new Vector3(0, 0, 0);
            }

            if (transform.position.y > yBoundary || transform.position.y < -yBoundary)
            //game over if the player gets off the boundaries.
            {
                gameManager.gameOver = true;
                gameManager.gameOverSound.Play();
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //game over after the player collides with a pillar
        if (gameManager.gameIsRunning)
        {
            gameManager.gameOver = true;
            gameManager.gameOverSound.Play();
        }
    }
}
