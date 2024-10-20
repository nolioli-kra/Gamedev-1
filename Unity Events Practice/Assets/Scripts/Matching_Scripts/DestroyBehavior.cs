using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBehavior : MonoBehaviour
{
    public float seconds = 1;
    private WaitForSeconds wfsObj;

    private IEnumerator DestroyRoutine()
    {
        wfsObj = new WaitForSeconds(seconds);
        yield return wfsObj;
        Destroy(gameObject);
    }

    public void Destroy()
    {
        wfsObj = new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
