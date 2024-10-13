using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEffects : MonoBehaviour
{
    public Renderer playerRenderer;
    public Color healColor = Color.green;
    public float colorChangeTime = 0.01f;

    private Color originalColor;
    public Material materialNow;

    void Start()
    {
        if (playerRenderer == null)
        {
            materialNow = playerRenderer.material;
            originalColor = playerRenderer.material.color;
        }
    }

    public void ChangeColorOnHeal()
    {
        if (playerRenderer != null)
        {
            materialNow.color = healColor;
            Invoke(nameof(ResetColor), colorChangeTime);
        }
    }

    public void ResetColor()
    {
        if (playerRenderer != null)
        {
            materialNow.color = originalColor;
        }
    }
}
