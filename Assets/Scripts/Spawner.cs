using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    //variables to determine the spawn behaviour of the pillars
    public GameObject pillar;
    private float spawnInterval = 3;
    private float topBound = 15;
    private float bottomBound = -29;
    private float xSpawnPoint = 90;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //repeat the SpawnPillar() function after a delay with set intervals.
        InvokeRepeating("SpawnPillars", 0, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
    }
  
    //function to constantly spawn pillars as long as the game is running.
    public void SpawnPillars()
    {
        if (gameManager.gameIsRunning)
        {
            Instantiate(pillar, RandomSpawnPoint(), transform.rotation);
        }
    }

    Vector3 RandomSpawnPoint()
    {
        //we find a spawn point with a randomised Y axis. These pillars spawn offscreen (same x axis).
        return new Vector3(xSpawnPoint, Random.Range(bottomBound, topBound), 0);
    }
}
