using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    // Play Button Functionality when clicked
    public void OnMyButtonClick()
    {
        // It loads the Game Scene/ starts the game
        Invoke("Reload", 2f);

        Debug.Log("Το κουμπί Play πατήθηκε!"); // Debug Message
    }
    
    private void Reload()
    {
        SceneManager.LoadScene("GameScene");
    }
}
