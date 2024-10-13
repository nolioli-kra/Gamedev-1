using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffects : MonoBehaviour
{
    public ParticleSystem deathEffect;
    
    //shrink death effect
    public float shrinkTime = 1f;
    public Vector3 finalScale = Vector3.zero;

    public void ActivateDeathParticles()
    {
        deathEffect.Play();
        Debug.Log("particles attempted to play");
    }

    public void ShrinkOnDeath()
    {
        StartCoroutine(Shrink());
    }
    
    //routine to shrink over time
    private IEnumerator Shrink()
    {
        Vector3 originalScale = transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < shrinkTime)
        {
            //lerp interpolates scale vectors over time
            transform.localScale = Vector3.Lerp(originalScale, finalScale, elapsedTime / shrinkTime);
            elapsedTime += Time.deltaTime;
            yield return null; //wait for frame
        }
        
        transform.localScale = finalScale;
        
        Destroy(gameObject);
    }
}
