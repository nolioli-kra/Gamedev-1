using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CoroutineBehavior : MonoBehaviour
{
    public UnityEvent startEvent, startCountEvent, repeatCountEvent, repeatUntilFalse, endCountEvent;

    public BoolValue canItRun;
    public IntData counterNum; //number of repetitions
    public float delay = 1f; //delay between fades
    private WaitForSeconds waitObj;

    public void Start()
    {
        startEvent.Invoke();
        waitObj = new WaitForSeconds(delay);
    }

    public void StartCounting()
    {
        StartCoroutine(Counting());
    }

    private IEnumerator Counting()
    {
        startCountEvent.Invoke();
        while (counterNum.intValue > 0)
        {
            repeatCountEvent.Invoke();
            counterNum.intValue--;
            yield return waitObj;
        } 
        endCountEvent.Invoke();
    }

    public void StartRepeatUntilFalse()
    {
        StartCoroutine(RepeatUntilFalse());
    }
    
    private IEnumerator RepeatUntilFalse()
    {
        while (canItRun.boolValue)
        {
            yield return waitObj;
            repeatUntilFalse.Invoke();
        }
    }
}
