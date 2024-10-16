using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class IntData : ScriptableObject
{
    public int intValue;

    public UnityEvent disableEvent;

    public void UpdateValue(int num)
    {
        intValue += num;
        //Debug.Log("score is currently: " + intValue);
    }

    public void SetValue(IntData obj)
    {
        intValue = obj.intValue;
    }

    public void CompareValue(IntData obj)
    {
        if (intValue >= obj.intValue)
        {
            
        } else
        {
            intValue = obj.intValue;
        }
    }

    public void ResetValue(int num)
    {
        intValue = num;
        //Debug.Log("score reset");
    }

    private void OnDisable()
    {
         disableEvent.Invoke();
    }
}
