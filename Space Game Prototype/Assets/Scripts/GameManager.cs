using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // int highScore = 0;
    bool gameHasEnded = false;

    //public int[] significantDeathCounts;
    //bool dialogueAtStart = false;
    //public static bool playerMovementStart = true;  // IF dialogueAtStart = true, this is false as set on Start func below, 
    // and only set to true (and dialogueAtStart set to false) after 
    // EndDialogue is called in DialogueManager. 
    public float restartDelay = 2.0f;

    //private int deathCount;             // reset at restart, levelcomplete, returntomenu, quitgame
    //private int totalDeathCount;        // reset at button press in optionsmenu (WIP)


    public GameObject sceneBeginUI;
    public GameObject completeLevelUI;
    public GameObject gameoverLevelUI;
    public GameObject menuChangeUI;
    //public GameObject score;

    void Awake()    // only for intro dialogue as shown above
    {
        Time.timeScale = 1f;

        //Score.highscore = PlayerPrefs.GetInt("Highscore", 0);
        //Debug.Log("Current Level Highscore: " + Score.currentLevelHighscoreTemp);
        //Debug.Log("Total Score: " + Score.totalscore);
        //Debug.Log("Highscore: " + Score.highscore);

        //deathCount = PlayerPrefs.GetInt("DeathCount", 0);
        //totalDeathCount = PlayerPrefs.GetInt("TotalDeathCount", 0);
        //Debug.Log("Current Death Count: " + deathCount);
        //Debug.Log("Total Death Count: " + totalDeathCount);

        //foreach (int count in significantDeathCounts)
        //Debug.Log("Significant Counts: " + count + " ");

        //foreach (int count in significantDeathCounts)
        //{
        //    if (deathCount == count)
        //    {
        //        dialogueAtStart = true;
        //        break;
        //    }
        //    else
        //        dialogueAtStart = false;
        //}

    //if (dialogueIntroToggle == true)
    //    dialogueAtStart = true;
    //else
    //   dialogueAtStart = false;

    //if (dialogueAtStart == true)
    //    playerMovementStart = false;
    //else
    //    playerMovementStart = true;

    }

    public void EndGame() // main branch of Restart when gameover
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Gameover.");
            gameoverLevelUI.SetActive(true);

            //Score.totalscore -= 25;
            //if (Score.score > Score.currentLevelHighscoreTemp)
            //{
            //    Score.totalscore -= Score.currentLevelHighscoreTemp;
            //    Score.currentLevelHighscoreTemp = Score.score;
            //    Score.totalscore += Score.score;
            //}

            //deathCount += 1;
            //totalDeathCount += 1;
            //PlayerPrefs.SetInt("DeathCount", deathCount);
            //PlayerPrefs.SetInt("TotalDeathCount", totalDeathCount);

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

        //if (Score.score > Score.currentLevelHighscoreTemp)
        //{
        //    Score.totalscore += Score.score - Score.currentLevelHighscoreTemp;
        //}

        //if (Score.totalscore > Score.highscore)
        //{
        //    PlayerPrefs.SetInt("Highscore", (int)Score.totalscore);
        //    Score.highscore = PlayerPrefs.GetInt("Highscore", 0);
        //}


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
        //Score.totalscore += Score.score - Score.currentLevelHighscoreTemp;

        //PlayerPrefs.SetInt("DeathCount", 0);
        //PlayerMovement.gameover = true;

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
        //Score.totalscore = 0;
        //Score.currentLevelHighscoreTemp = 0;

        FindObjectOfType<AudioManager>().Play("ButtonPress");
        //Debug.Log("Game is starting...");
        menuChangeUI.SetActive(true); //LoadNextLevel function is called from animation from NextLevel script
    }

    public void StartSceneTransitionClose()
    {
        //PlayerMovement.gameover = false;
        sceneBeginUI.SetActive(false); //this is called at the end of the scene begin transition to make sure it's off
    }

    //private void OnApplicationQuit()
    //{
    //    PlayerPrefs.SetInt("DeathCount", 0);
    //    PlayerPrefs.SetInt("TotalDeathCount", 0);
    //}
}
