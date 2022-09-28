using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void LoadNextLevel()
    {
        //if (SceneManager.GetActiveScene().buildIndex == 10) // if at level 10 and level is completed, highscore is updated
        //{
        //    if (Score.totalscore > Score.highscore)
        //    {
        //        PlayerPrefs.SetInt("Highscore", (int)Score.totalscore);
        //        Score.highscore = PlayerPrefs.GetInt("Highscore", 0);
        //    }

        //}
        //Score.currentLevelHighscoreTemp = 0;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LevelCompleteAudio()
    {
        FindObjectOfType<AudioManager>().Play("LevelComplete");
    }
}
