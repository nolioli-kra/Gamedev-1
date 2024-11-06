using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class isGrounded : ScriptableObject
{
    public bool isOnGround;

    public void setIsOnGround(bool value)
    {
        isOnGround = value;    
    }
}
