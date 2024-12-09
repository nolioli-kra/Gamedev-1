using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    public IntData timeScore;
    public UnityEvent startEvent;

    private bool isTiming;
    private float startTime;

    private void Start()
    {
        startEvent.Invoke();
        timeScore.elapsedTime = 0;
    }

    public void StartTimer()
    {
        isTiming = true;
        startTime = Time.time;
    }

    public void StopTimer()
    {
        if (isTiming)
        {
            isTiming = false;
            timeScore.elapsedTime = Time.time - startTime;
            Debug.Log("Final time:" + timeScore.elapsedTime + " seconds");
        }
    }

    private void Update()
    {
        if (isTiming)
        {
            timeScore.elapsedTime = Time.time - startTime;
        }
    }
}
