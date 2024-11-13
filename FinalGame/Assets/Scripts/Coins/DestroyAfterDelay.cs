using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{
    public float delay = 2f;

    public void DestroyWithDelay()
    {
        Destroy(gameObject, delay);
    }
}
