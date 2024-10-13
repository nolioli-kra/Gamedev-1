using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;
    
    public UnityEvent onTakeDamage;
    public UnityEvent onDeath;
    public UnityEvent onHeal;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        onTakeDamage.Invoke(); //trigger when damage is taken in any form

        if (currentHealth <= 0)
        {
            onDeath.Invoke();
        }
    }

    public void Heal(int heal)
    {
        currentHealth += heal;
        onHeal.Invoke(); //trigger when healed
    }
}
