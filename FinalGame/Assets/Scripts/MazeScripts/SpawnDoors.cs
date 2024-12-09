using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DoorManager : MonoBehaviour
{
    public UnityEvent startEvent, openDoor1;
    public UnityEvent openDoor2;
    public UnityEvent openDoor3;
    public float interval = 2f;

    private Coroutine doorCoroutine;

    void Start()
    {
        // StartDoorCoroutine();
        startEvent.Invoke();
    }

    public void RestartEvent()
    {
        startEvent.Invoke();
    }

    public void StartDoorCoroutine()
    {
        if (doorCoroutine == null)
        {
            doorCoroutine = StartCoroutine(OpenDoorsAtIntervals());
        }
    }

    public void StopDoorCoroutine()
    {
        if (doorCoroutine != null)
        {
            StopCoroutine(doorCoroutine);
            doorCoroutine = null;
        }
    }

    IEnumerator OpenDoorsAtIntervals()
    {
        // Open door 1
        openDoor1.Invoke();
        yield return new WaitForSeconds(interval);

        // Open door 2
        openDoor2.Invoke();
        yield return new WaitForSeconds(interval);

        // Open door 3
        openDoor3.Invoke();
    }
}


