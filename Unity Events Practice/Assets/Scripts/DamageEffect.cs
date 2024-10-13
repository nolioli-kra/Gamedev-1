using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    public Renderer playerRenderer;
    public Color damageColor = Color.red;
    public float colorChangeTime = 0.01f;

    private Color originalColor;
    public Material materialInstance;

    void Start()
    {
        if (playerRenderer == null)
        {
            materialInstance = playerRenderer.material;
            originalColor = playerRenderer.material.color;
        }
    }

    public void ChangeColorOnDamage()
    {
        if (playerRenderer != null)
        {
            materialInstance.color = damageColor;
            Invoke(nameof(ResetColor), colorChangeTime);
        }
    }

    public void ResetColor()
    {
        if (playerRenderer != null)
        {
            materialInstance.color = originalColor;
        }
    }
}
