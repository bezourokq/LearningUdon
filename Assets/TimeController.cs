using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{

    private Text bestTime;
    private Text time;
    private Text completet;

    public bool controller;

    public float timePassed = 0;

    private int completedLevels = 0;



    // Start is called before the first frame update
    void Start()
    {
        bestTime = GameObject.Find("BestTimeText").GetComponent<Text>();
        bestTime.text = DisplayTime(0f);
        time = GameObject.Find("TimeText").GetComponent<Text>();
        time.text = DisplayTime(0f);
        completet = GameObject.Find("CompletetText").GetComponent<Text>();
        completet.text = "Incomplete";
        completet.color = Color.red;

    }

    // Update is called once per frame
    void Update()
    {
        if (controller)
        {
            timePassed += Time.deltaTime;

            time.text = DisplayTime(timePassed);
        }
    }

    public void StopTimer()
    {
        controller = false;
    }

    public float GetTimer()
    {
        return timePassed;
    }

    public void ResetTimer()
    {
        timePassed = 0;
        time.text = DisplayTime(timePassed);
    }

    public void StartTimer()
    {
        if(timePassed == 0f)
        {
            controller = true;
        }
    }

    public float setBest(float timePassedOld)
    {
        if((timePassedOld > timePassed) || timePassedOld == 0f)
        {
            return timePassed;
        }
        else
        {
            return timePassedOld;
        }
  
    }

    public void setCompleted(float besttime)
    {
        if(besttime != 0f)
        {
            completet.text = "Completed";
            completet.color = Color.green;
        }
        else
        {
            completet.text = "Incomplete";
            completet.color = Color.red;
        }
       
    }

    public void setBestDisplay(float timePassedBest)
    {
        bestTime.text = DisplayTime(timePassedBest);
    }

        private string DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float Mseconds = Mathf.FloorToInt((timeToDisplay * 1000) - (seconds * 1000) - (minutes* 60000));

        return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, Mseconds);
    }
}
