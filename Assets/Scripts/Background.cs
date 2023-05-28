using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float speed = 15;
    private Vector3 resetPoint;
    private float bgHalfWidth;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //set position values to be able to reset the background.
        resetPoint = transform.position;
        //getting the middle point of the box collider
        bgHalfWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //background onlyy movies if the game is running.
        if (gameManager.gameIsRunning == true)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        //if the current x position is smaller than the original starting point - middle point of the collider
        if (transform.position.x < resetPoint.x - bgHalfWidth)
        {
            //setting the current position to the reset position we set at the Start() function
            transform.position = resetPoint;
        }   
    }
}
