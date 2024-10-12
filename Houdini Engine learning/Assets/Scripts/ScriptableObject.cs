using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject")]
public class Card : ScriptableObject
{
    public string objName;
    public string description;

    public Sprite artwork;

    public int manaCost;
    //public int attackPower;
    //public int health;

    public void PrintName()
    {
        Debug.Log(objName + ", " + description + ", " + manaCost);
    }
}
