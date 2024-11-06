using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharStats : ScriptableObject
{
    public float speed;
    public float jumpHeight;
    public float gravity = -9.8f;
}
