using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoolValue : ScriptableObject
{
    public bool boolValue;

    public void setBoolValue(bool value)
    {
        boolValue = value;
    }

    public void resetBoolValue()
    {
        boolValue = false;
    }
}
