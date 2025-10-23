using UnityEngine;
using UnityEngine.UI;

public class InfoButton : MonoBehaviour
{
    public GameObject Im1;
    public GameObject Im2;

    void Start()
    {
        Im2.SetActive(false);
    }
    
    // Info Button Functionality when clicked
    public void OnMyButtonClick()
    {
        // It disactivates title image and activates info image
        Im1.SetActive(false);
        Im2.SetActive(true);

        Debug.Log("Το κουμπί Info πατήθηκε!"); //Debug Message
    }
}
