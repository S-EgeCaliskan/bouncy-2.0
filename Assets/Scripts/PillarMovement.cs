using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarMovement : MonoBehaviour
{
    private Rigidbody rb;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Pillars move to left depending on their speed.
        Vector3 leftMovement = new Vector3(-1, 0, 0);
        if (gameManager.gameIsRunning)
        {
            rb.MovePosition(rb.position + leftMovement * Time.deltaTime * gameManager.pillarSpeed);
        }
    }
}
