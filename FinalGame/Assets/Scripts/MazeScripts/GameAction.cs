using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class GameAction : ScriptableObject
{
    public UnityEvent actionEvent;

    public void InvokeAction()
    {
        if (actionEvent != null)
        {
            actionEvent.Invoke();
        }
    }
}
