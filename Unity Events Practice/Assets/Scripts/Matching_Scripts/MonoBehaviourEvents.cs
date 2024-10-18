using System;
using UnityEngine;
using UnityEngine.Events;

public class MonoBehaviourEvents : MonoBehaviour
{
    public UnityEvent OnStartGame, OnAwake;
    
    void Start()
    {
        OnStartGame.Invoke();    
    }

    private void OnEnable()
    {
        OnAwake.Invoke();
    }
}
