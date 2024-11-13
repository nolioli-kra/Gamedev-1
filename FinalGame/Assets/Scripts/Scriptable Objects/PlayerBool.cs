using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerBool : ScriptableObject
{
    public bool playerBool;

    public void setBool(bool value)
    {
        playerBool = value;
    }
}
