using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitManager : MonoBehaviour
{
    public TimeManager timer;
    public GameObject player;
    public GameObject box1;
    public GameObject box2;
    public float timeLoss = 15f; // Players penalty

    // UI variables
    public TMPro.TMP_Text victoryText;
    public AudioSource source;

    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;

    void Start()
    {
        victoryText.enabled = false;
    }

    private void OnCollisionEnter(Collision collision) // it detects player's collision with other game Objects
    {
        if (collision.gameObject.tag == "Enemies") // Collisions with enemies
        {
            Debug.Log("Έγινε collision με enemy!"); // Debug Message
            source.PlayOneShot(clip2);
            Destroy(collision.gameObject); // It destroys the enemy

            if (timer.currentTime > timeLoss)
            {
                timer.currentTime -= timeLoss; // With collision Enemy steals time from the player
            }
            else
            {
                // Or ends the game (if player's time is already less than the penalty)
                timer.currentTime = 0;
                timer.GameOver();
            }
        }
        if (collision.gameObject.name == "Exit") // collision with the exit point
        {
            Debug.Log("Κερδισες"); // Debug Message
            Victory(); // Victory Function
        }
        if (collision.gameObject.name == "Point") // it forces the player to change root if he is fast
        {
            if (timer.currentTime > 59f)
            {
                Debug.Log("Άλλαξε κατεύθυνση"); // Debug Message

                source.PlayOneShot(clip3);
                // root change
                box1.SetActive(false);
                box2.SetActive(true);
                Destroy(collision.gameObject);
                
            }
        }
    }

    // It loads the Menu Scene
    private void Reload()
    {
        SceneManager.LoadScene("MenuScene");
    }

    // It Desactivates the player object on scene
    private void DestroyPlayer()
    {
        player.SetActive(false);
    }

    public void Victory()
    {
        timer.StopTimer(); // Time countdown stops
        
        victoryText.enabled = true; // Victory message ans sound appear
        source.PlayOneShot(clip1);

        Invoke("DestroyPlayer", 1f); // Player gets desactivated and menu scene reloaded
        Invoke("Reload", 5f);
    }
}
