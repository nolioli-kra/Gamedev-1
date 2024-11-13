using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Handler : MonoBehaviour
{
    public GameAction actionToExecute;
    public UnityEvent startEvent, stopEvent, doorZoneEnter;

    public void TriggerAction()
    {
        if (actionToExecute != null)
        {
            actionToExecute.InvokeAction();
        }
        else
        {
            Debug.Log("No action defined");
        }
    }
}
