using System.Collections;
using System.Collections.Generic;
// using Unity.Mathematics;
using UnityEngine;

public class TrajSceneController : MonoBehaviour
{
    public GameObject shooter;
    public float velocity, angle;
    public float winVelocity = 25;
    public float winAngle = 91;
    public bool winCriteria = false;
    // Start is called before the first frame update
    void Start()
    {
        winVelocity = 25;
        winAngle = 91;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = Mathf.Floor(shooter.GetComponent<shooter>().velocity);
        angle = Mathf.Floor(shooter.GetComponent<shooter>().angle);
        if (velocity == winVelocity && angle == winAngle)
        {
            winCriteria = true;
        }
        else
        {
            winCriteria = false;
        }

        if (winCriteria && Input.GetKeyDown(KeyCode.A))
        {
            win(); 
        }
        if (!winCriteria && Input.GetKeyDown(KeyCode.A))
        {
            lose();
        }
    }

    public void win()
    {
        FindObjectOfType<AudioManager>().Play("winTraj"); //NAME OF AUDIO 'winTraj'
        Time.timeScale = 1.0f;
        Invoke("NextScene", 2.0f);
    }

    public void lose()
    {
        FindObjectOfType<AudioManager>().Play("loseTraj"); //NAME OF AUDIO 'loseTraj'
    }

    public void NextScene()
    {
        FindObjectOfType<GameManager>().StartGameTransition();
    }


}
