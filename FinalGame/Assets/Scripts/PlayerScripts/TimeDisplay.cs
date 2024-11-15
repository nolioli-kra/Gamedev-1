using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour
{
    public IntData timeScore;
    public Text timeText;

    public void Update()
    {
        timeText.text = "Time: " + timeScore.elapsedTime.ToString("F1") + " seconds";
    }
}
