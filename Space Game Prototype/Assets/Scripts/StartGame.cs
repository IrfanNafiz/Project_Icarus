using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class StartGame : MonoBehaviour
{
    public Button startButtonSelect;
    public void Start()
    {
        startButtonSelect.Select();
    }

    public void GameStartButton()
    {
       FindObjectOfType<GameManager>().StartGameTransition();
    }

    
}
