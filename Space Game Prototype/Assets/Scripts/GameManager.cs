using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 2.0f;

    public GameObject sceneBeginUI;
    public GameObject completeLevelUI;
    public GameObject gameoverLevelUI;
    public GameObject menuChangeUI;

    void Awake()    // only for intro dialogue as shown above
    {
        Time.timeScale = 1f;
    }

    public void EndGame() // main branch of Restart when gameover
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Gameover.");
            gameoverLevelUI.SetActive(true);

            Invoke("Restart", restartDelay);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }// made so that it can be invoked with delay from EndGame due to transition

    public void ReturnToMenu()
    {
        FindObjectOfType<AudioManager>().Play("ButtonPress");

        PlayerPrefs.SetInt("DeathCount", 0);

        if (gameHasEnded == false)
        {
            Time.timeScale = 1f; //due to pause menu changing it to 0f
            gameHasEnded = true;
            //Debug.Log("Returning to Menu.");
            gameoverLevelUI.SetActive(true);
            Invoke("Menu", restartDelay);
        }
    }
    void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex);
        // sets buildindex to 0 i.e. menu (note menu should always be at build index 0 for this to work)
    }   // made so that it can be invoked with delay from ReturnToMenu due to transition

    public void LevelComplete()
    {
        completeLevelUI.SetActive(true); //LoadNextLevel function is called from animation from NextLevel script
    }

    public void QuitGame() //have alternate script for this one function too
    {
        FindObjectOfType<AudioManager>().Play("ButtonPress");
        Debug.Log("Closing Application...");
        Application.Quit();
    }

    public void StartGameTransition()
    {
        FindObjectOfType<AudioManager>().Play("ButtonPress");
        //Debug.Log("Game is starting...");
        menuChangeUI.SetActive(true); //LoadNextLevel function is called from animation from NextLevel script
    }

    public void StartSceneTransitionClose()
    {
        sceneBeginUI.SetActive(false); //this is called at the end of the scene begin transition to make sure it's off
    }

}
