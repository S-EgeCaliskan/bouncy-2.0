using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI pauseText;
    public Button restartButton;
    private int score;
    public bool gameIsRunning = true;
    public bool paused = false;
    public bool gameOver = false;
    public AudioSource gameOverSound;
    public AudioSource music;
    public GameObject startMenu;
    public int pillarSpeed;
    private PlayerController playerController;
    private Rigidbody rb;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        rb = GameObject.Find("Player").GetComponent<Rigidbody>();

        //taking care of the text/button objects in the game.
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        startMenu.gameObject.SetActive(true);
        titleText.gameObject.SetActive(true);
        pauseText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //stop the music if the game is paused/over.
        if(gameIsRunning == false || gameOver == true)
        {
            music.Stop();
        }
        if(gameOver == true)
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        //input to (un)pause the game.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            Pause();
        }
    }
    //function to pause the game and show the main menu.
    public void Pause()
    {
       //logic to pause / unpause and display or hide the menus.
        if(paused)
        {
            restartButton.gameObject.SetActive(true);
            pauseText.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            restartButton.gameObject.SetActive(false);
            pauseText.gameObject.SetActive(false);
            Time.timeScale = 1;
        }

    }
    //function to update the score by one.
    public void ScoreUpdate()
    {
        score += 1;
        scoreText.text = "Score: " + score;
    }
    //starts the game
    public void StartGame()
    {
        titleText.gameObject.SetActive(false);
        startMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
        score = 0;
        scoreText.text = "Score: " + score;
        music.Play();
        gameIsRunning = true;
        gameOver = false;
        //give the player a free jump at the beginning
        rb.AddForce(Vector3.up * playerController.bounceForce, ForceMode.Impulse);
        //reset the velocity after every bounce
        rb.velocity = new Vector3(0, 0, 0);
    }
    //to change the difficulty of the game via the speeds. The higher the speed, the easier the game:
    //As with slower pillar speed, the pillars stack closer, making it difficult to navigate through them.
    //By default, easy is set to 13, normal to 10, hard to 7. These can be tweeaked from within the Unity engine.
    public void SetPillarSpeed(int PillarSpeed)
    {
        pillarSpeed = PillarSpeed;
    }
    //restarts  
    public void RestartGame()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        gameOver = false;
    }
}
