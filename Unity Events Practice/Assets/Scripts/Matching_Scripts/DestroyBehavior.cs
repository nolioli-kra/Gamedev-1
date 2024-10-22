using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBehavior : MonoBehaviour
{
    public float seconds = 1f;
    public float checkInterval = 0.5f;
    private WaitForSeconds wfsObj;

    public void Destroy()
    {
        StartCoroutine(DestroyRoutine());
    }

    public void DestroyTagRepeating()
    {
        InvokeRepeating(nameof(DestroyWithTag), checkInterval, checkInterval);
    }
    public void DestroyWithTag()
    {
        GameObject[] cylinders = GameObject.FindGameObjectsWithTag("Cylinders");

        StartCoroutine(DestroyCylindersWithDelay(cylinders));
    }
    
    private IEnumerator DestroyRoutine()
    {
        wfsObj = new WaitForSeconds(seconds);
        yield return wfsObj;
        Destroy(gameObject);
    }
    
    IEnumerator DestroyCylindersWithDelay(GameObject[] cylinders)
    {
        yield return new WaitForSeconds(seconds);
        foreach (GameObject cylinder in cylinders)
        {
            Destroy(cylinder);
        }
    }
}
