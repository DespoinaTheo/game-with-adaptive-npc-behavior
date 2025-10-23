using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeManager : MonoBehaviour
{
    // Player's time variables
    public float halfMin = 6;
    private float startTime;
    public float currentTime;

    // UI variables
    public TMPro.TMP_Text timerText;
    public TMPro.TMP_Text gameOverText;
    public AudioSource source;

    public AudioClip clip;


    public GameObject player;

    private bool isRunning = true; // flag for running time or not
    


    void Start()
    {
        // initializes time variables
        startTime = 30 * halfMin;
        currentTime = startTime;

        gameOverText.enabled = false;
    }

    void Update()
    {
        if (isRunning && currentTime > 0) // flag check
        {
            currentTime -= Time.deltaTime; // time countdown
            // If time remaining is < or = 0 the game is over
            if (currentTime < 0)
            {
                currentTime = 0;
                GameOver();
            }
        }
        DisplayTime(currentTime); // UI/ time display on screne
    }

    void DisplayTime(float timeToDisplay)
    {
        // Minutes and seconds calculation
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        if (timerText != null)
        {
            // UI text Update
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            // if current time < 30 seconds the text turns red and bold 
            if (timeToDisplay < 30f)
            {
                timerText.color = Color.red;
                timerText.fontStyle = FontStyles.Bold;
            }
            else
            {
                // Default text setting
                timerText.color = Color.white;
                timerText.fontStyle = FontStyles.Normal;
            }
        }
    }


    public void GameOver()
    {
        if (currentTime == 0)
        {
            // Game Over UI gets activated
            gameOverText.enabled = true;
            source.PlayOneShot(clip);

            Invoke("Reload", 5f); // Menu scene is reloaded
            Invoke("DestroyPlayer", 1f); // Player is desactivated from scene
        }
    }
    // It loads the Menu Scene
    private void Reload()
    {
        SceneManager.LoadScene("MenuScene");
    }

    // It Desactivates the player object on scene

    public void DestroyPlayer()
    {
        player.SetActive(false);
    }

    // Function that stop time countdown (when player wins)
    public void StopTimer()
    {
        isRunning = false;
    }
}
