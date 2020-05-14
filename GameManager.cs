using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    // Allows the instance to be accesable from any script without referencing the object
    public static GameManager instance;

    public bool gameOver = false;
    public bool gameWon = false;
    public GameObject gameOverScreen;
    public GameObject gameWonScreen;

    public float timer = 5;
    public float time;
    bool countdown;

    public int enemyKills;

    private bool previousGameState;

    private void Awake()
    {
        // makes sure that only one GameManager exists in the scene
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {

        time = timer;
        countdown = false;

        enemyKills = 0;

        gameOver = false;
        gameWon = false;
        previousGameState = false;
        gameOverScreen.SetActive(false);
        gameWonScreen.SetActive(false);

    }

    public void KillEnemy()
    {

        enemyKills++;

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyKills == 7)
        {
            gameWon = true;
        }

        if (gameOver == true && previousGameState == false)
        {
            gameOverScreen.SetActive(true);

            previousGameState = gameOver;

            countdown = true;
        }

        if (gameWon == true && previousGameState == false)
        {
            gameWonScreen.SetActive(true);

            previousGameState = gameWon;

            countdown = true;
        }

        if (countdown == true)
        {
            time -= Time.deltaTime;
        }

        if (previousGameState != false && time <= 0)
        {

            Application.LoadLevel(Application.loadedLevel);

            time = timer;
        }
    }
}
