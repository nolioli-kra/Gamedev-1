using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatData : ScriptableObject
{
    public float floatValue;

    public void SetValue(float num)
    {
        floatValue = num;
    }

    public void UpdateValue(float num)
    {
        floatValue += num;
    }
}
