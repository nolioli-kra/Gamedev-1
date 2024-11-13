using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCollide : MonoBehaviour
{
    public Handler actionHandler;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            actionHandler.doorZoneEnter.Invoke();
        }
    }
}
