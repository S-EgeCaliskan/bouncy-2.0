using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    private string obstacleTag = "Pillar";
    private float destroyAxis = -60;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Despawn the pillars when they go off-screen
        if (transform.position.x < destroyAxis && gameObject.CompareTag(obstacleTag))
        {
            Destroy(gameObject);
        };
    }
    //score updates when the pillars and the scoretrigger object collide.
    private void OnTriggerEnter(Collider other)
    {
        gameManager.ScoreUpdate();
    }
}
