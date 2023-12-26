using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverCanvas;
    public GameObject gameCanvas;
    public GameObject pauseCanvas;
    private Health healthPlayer;
    public Button pauseButton;
    // Start is called before the first frame update

    public enum Gamestates
    {
        Playing,
        Paused,
        GameOver
    }

    public Gamestates gameState = Gamestates.Playing;
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        healthPlayer = player.GetComponent<Health>();
        pauseButton.onClick.AddListener(TogglePause);
    }

    void Update()
    {
        switch (gameState)
        {
            case Gamestates.Playing:

                if (!healthPlayer.isAlive)
                {
                    gameState = Gamestates.GameOver;
                    gameCanvas.SetActive(false);
                    gameOverCanvas.SetActive(true);
                }
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    TogglePause();
                }
                break;
            case Gamestates.Paused:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    TogglePause();
                }
                break;
        }

    }
    void TogglePause()
    {
        if (gameState == Gamestates.Playing)
        {
            Time.timeScale = 0f;
            gameState = Gamestates.Paused;
            gameCanvas.SetActive(false);
            gameOverCanvas.SetActive(false);
            pauseCanvas.SetActive(true);
        }
        else if (gameState == Gamestates.Paused)
        {
            Time.timeScale = 1f;
            gameState = Gamestates.Playing;
            gameCanvas.SetActive(true);
            gameOverCanvas.SetActive(false);
            pauseCanvas.SetActive(false);
        }
    }
}
