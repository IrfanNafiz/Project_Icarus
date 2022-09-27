using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour
{
    public float slowDownFactor = 0.50f;
    public float slowDownLength = 1f;
    public float numberOfPowers = 3f;
    float fixedTimestep = 0.01f; // must match with "Project Settings => Time => Fixed timestep"

    public Animator slowmotionVignette;

    void Update()
    {
        if (PauseMenuUI.gameIsPaused == false)
        {
            Time.timeScale += (1 / slowDownLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, slowDownFactor, 1f);


            if (Time.timeScale == 1.0f)
                Time.fixedDeltaTime = fixedTimestep;

            if (numberOfPowers != 0)
            {
                if (Input.GetKeyDown("left shift") || Input.GetKeyDown("right shift"))
                {
                    slowmotionVignette.SetBool("SlowMotion", true);
                }

                if (Input.GetKey("left shift") || Input.GetKey("right shift"))
                    SlowMotion();

                if (Input.GetKeyUp("left shift") || Input.GetKeyUp("right shift"))
                {
                    slowmotionVignette.SetBool("SlowMotion", false);
                    numberOfPowers -= 1;
                    // StartCoroutine("SlowmotionTimer");
                }
            }
        }

        //***ONLY FOR WHEN SLOWMOTION WANTS TO BE CONTROLLED INDEFINITELY***

        //if (Input.GetKeyDown("left shift"))
        //    slowmotionVignette.SetBool("SlowMotion", true);
        //if (Input.GetKeyUp("left shift"))
        //{
        //    slowmotionVignette.SetBool("SlowMotion", false);
        //    // StartCoroutine("SlowmotionTimer");
        //}
        //if (Input.GetKey("left shift"))
        //    SlowMotion();
    }

    IEnumerator SlowmotionTimer()
    {
        yield return new WaitForSecondsRealtime(slowDownLength);
    }

    public void SlowMotion()
    { 
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = fixedTimestep * Time.timeScale;
    }

}

