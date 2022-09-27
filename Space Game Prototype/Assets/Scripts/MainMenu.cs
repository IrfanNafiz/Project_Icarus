using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI; // probably couldve used findobjectoftype
    public GameObject optionsMenuUI;
    public bool optionsToggle = false;
    public Button startButton;
    public Button backButton;
    //public Text highscore; // for reference to highscoretext in the MainMenuUI and CreditsUI


    void Start()
    {
        startButton.Select();
        //highscore.text = Score.highscore.ToString(); 
    }
    public void OptionsMenuToggle()
    {
        FindObjectOfType<AudioManager>().Play("ButtonPress");

        if (optionsToggle == false) // for the options button in main menu
        {
            optionsToggle = true;
            optionsMenuUI.SetActive(true);
            mainMenuUI.SetActive(false);

            backButton.Select();
        }
        else // for the back button in options menu
        {
            optionsToggle = false;
            optionsMenuUI.SetActive(false);
            mainMenuUI.SetActive(true);

            //highscore.text = Score.highscore.ToString();

            startButton.Select();

        }
    }

}
