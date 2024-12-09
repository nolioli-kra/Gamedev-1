using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CountDownRoutine : MonoBehaviour
{
    public float countdownTime = 5f; // Set the countdown time in seconds
    public UnityEvent countDownEvent;

    void Start()
    {
        // Optionally start the countdown at the beginning
        StartCoroutine(CountdownCoroutine());
    }

    public void StartCountdown()
    {
        StartCoroutine(CountdownCoroutine());
    }

    private IEnumerator CountdownCoroutine()
    {
        float remainingTime = countdownTime;

        while (remainingTime > 0)
        {
            Debug.Log("Time remaining: " + remainingTime);
            yield return new WaitForSeconds(1f);
            remainingTime--;
        }

        Debug.Log("Countdown finished!");
        countDownEvent.Invoke();
    }
}

