using UnityEngine;

[CreateAssetMenu]
public class IntData : ScriptableObject
{
    public int intValue;

    public void UpdateValue(int num)
    {
        intValue += num;
        Debug.Log("score is currently: " + intValue);
    }

    public void ResetValue(int num)
    {
        intValue = num;
        Debug.Log("score reset");
    }
}
