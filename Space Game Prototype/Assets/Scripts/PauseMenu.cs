using UnityEngine;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseMenuFadeOutOnReturn;
    public Button resumeButton;

    //public Text totalscore; // for reference to highscoretext in the MainMenuUI and CreditsUI
    //public Text highscore; // for reference to highscoretext in the MainMenuUI and CreditsUI

    void Update()
    {
        //if (gameIsPaused == true)
        //{
        //    int total = (int)Score.totalscore;
        //    totalscore.text = total.ToString();
        //    highscore.text = Score.highscore.ToString();
        //}

        //if (PlayerMovement.gameover == false)
        //{
        //    if (Input.GetButtonDown("Cancel"))
        //    {
        //        if (gameIsPaused == false)
        //        {
        //            Pause();
        //        }
        //        else
        //        {
        //            Resume();
        //        }
        //    }
        //}
        //else
        //    return;
    }

    void Pause()
    {
        FindObjectOfType<AudioManager>().Play("ButtonPress");
        gameIsPaused = true;
        //Debug.Log("Game is paused.");
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        resumeButton.Select();
    }

    public void Resume()
    {
        FindObjectOfType<AudioManager>().Play("ButtonPress");
        gameIsPaused = false;
        //Debug.Log("Game is resumed.");
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }

    public void ReturntoMenu()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        pauseMenuFadeOutOnReturn.SetActive(true);
        FindObjectOfType<GameManager>().ReturnToMenu();
    }

    public void Quit()
    {
        FindObjectOfType<GameManager>().QuitGame();
    }
}
