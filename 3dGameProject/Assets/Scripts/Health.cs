using UnityEngine;
using UnityEngine.UI; // Import the UI namespace

public class Health : MonoBehaviour
{
    public enum deathAction { loadLevelWhenDead, doNothingWhenDead };

    public float healthPoints = 1f;
    public float respawnHealthPoints = 1f;      // base health points

    public int numberOfLives = 1;               // lives and variables for respawning
    public bool isAlive = true;

    public GameObject explosionPrefab;

    public deathAction onLivesGone = deathAction.doNothingWhenDead;

    public string LevelToLoad = "";

    private Vector3 respawnPosition;
    private Quaternion respawnRotation;

    public Text healthText;  // Reference to the UI Text element

    // Use this for initialization
    void Start()
    {
        // store initial position as respawn location
        respawnPosition = transform.position;
        respawnRotation = transform.rotation;

        if (LevelToLoad == "") // default to current scene 
        {
            LevelToLoad = Application.loadedLevelName;
        }

        // Link UI Text element within the Canvas
        Canvas canvas = FindObjectOfType<Canvas>(); // Assuming there's only one canvas
        if (canvas != null)
        {
            healthText = canvas.transform.Find("HealthText").GetComponent<Text>();
            if (healthText == null)
            {
                Debug.LogError("HealthText not found!");
            }
        }
        else
        {
            Debug.LogError("Canvas not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Update UI Text with health points
        if (healthText != null)
        {
            healthText.text = "HP: " + healthPoints.ToString();
        }

        if (healthPoints <= 0)
        {
            numberOfLives--;

            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }

            if (numberOfLives > 0)
            {
                transform.position = respawnPosition;
                transform.rotation = respawnRotation;
                healthPoints = respawnHealthPoints;
            }
            else
            {
                isAlive = false;

                switch (onLivesGone)
                {
                    case deathAction.loadLevelWhenDead:
                        Application.LoadLevel(LevelToLoad);
                        break;
                    case deathAction.doNothingWhenDead:
                        // do nothing, death must be handled in another way elsewhere
                        break;
                }
                Destroy(gameObject);
            }
        }
    }

    public void ApplyDamage(float amount)
    {
        healthPoints = Mathf.Max(0, healthPoints - amount);  // Ensure healthPoints does not go below zero
    }

    public void ApplyHeal(float amount)
    {
        healthPoints = Mathf.Min(respawnHealthPoints, healthPoints + amount);  // Ensure healthPoints does not exceed respawnHealthPoints
    }

    public void ApplyBonusLife(int amount)
    {
        numberOfLives += amount;
    }

    public void updateRespawn(Vector3 newRespawnPosition, Quaternion newRespawnRotation)
    {
        respawnPosition = newRespawnPosition;
        respawnRotation = newRespawnRotation;
    }
}
