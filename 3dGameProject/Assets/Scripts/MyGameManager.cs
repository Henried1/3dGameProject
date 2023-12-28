using UnityEngine;
using UnityEngine.UI;

public class MyGameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverCanvas;
    public GameObject gameCanvas;
    public GameObject pauseCanvas;
    public GameObject navigationHUD;
    public GameObject informationCanvas;
    private Health healthPlayer;
    public Button pauseButton;
    public Button informationButton;

    public enum Gamestates
    {
        Playing,
        Paused,
        GameOver,
        Information
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
        informationButton.onClick.AddListener(ToggleInformation);
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

                // Check for collision with the green ball
                CheckGreenBallCollision();

                break;
            case Gamestates.Paused:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    TogglePause();
                }
                break;
        }
    }

    void CheckGreenBallCollision()
    {
        if (gameState == Gamestates.Playing)
        {
            GameObject greenBall = GameObject.FindWithTag("GreenBall");

            if (greenBall != null)
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

                foreach (GameObject enemy in enemies)
                {
                    if (player.GetComponent<Collider>().bounds.Intersects(greenBall.GetComponent<Collider>().bounds))
                    {
                        gameState = Gamestates.Information;
                        Time.timeScale = 0f;
                        gameCanvas.SetActive(false);
                        gameOverCanvas.SetActive(false);
                        pauseCanvas.SetActive(false);
                        informationCanvas.SetActive(true);

                        Destroy(greenBall);

                        // Destroy each enemy
                        Destroy(enemy);
                    }
                }
            }
        }
    }

    void TogglePause()
    {
        if (gameState == Gamestates.Playing || gameState == Gamestates.Information)
        {
            Time.timeScale = 0f;
            gameState = Gamestates.Paused;
            gameCanvas.SetActive(false);
            gameOverCanvas.SetActive(false);
            pauseCanvas.SetActive(true);
            informationCanvas.SetActive(false);
            navigationHUD.SetActive(false);
        }
        else if (gameState == Gamestates.Paused)
        {
            Time.timeScale = 1f;
            gameState = Gamestates.Playing;
            gameCanvas.SetActive(true);
            gameOverCanvas.SetActive(false);
            pauseCanvas.SetActive(false);
            informationCanvas.SetActive(false);
            navigationHUD.SetActive(true);
        }
    }

    void ToggleInformation()
    {
        if (gameState == Gamestates.Information)
        {
            Time.timeScale = 1f;
            gameState = Gamestates.Playing;
            gameCanvas.SetActive(true);
            gameOverCanvas.SetActive(false);
            pauseCanvas.SetActive(false);
            informationCanvas.SetActive(false);
        }
    }
}
