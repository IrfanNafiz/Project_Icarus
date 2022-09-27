using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void Quit()
    {
        FindObjectOfType<AudioManager>().Play("ButtonPress");
        Debug.Log("Closing Application...");
        Application.Quit();
    }
}
