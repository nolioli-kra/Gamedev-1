using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyHeal : MonoBehaviour
{
    public int heal = 10;

    private void OnCollisionEnter(Collision playerCollision)
    {
        if (playerCollision.gameObject.CompareTag("Player"))
        {
            Health playerHealth = playerCollision.gameObject.GetComponent<Health>();

            if (playerHealth != null)
            {
                playerHealth.Heal(heal);
                
                Debug.Log("player recieved Health");
            }
        }
    }
}
