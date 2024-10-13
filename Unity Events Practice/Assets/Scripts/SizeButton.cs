using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SizeButton : MonoBehaviour
{
    public UnityEvent onSizeChange;
    
    public Vector3 smallSize = new Vector3(0.1f, 0.1f, 0.1f);
    public Vector3 normalSize = new Vector3(1f,1f,1f);
    public Vector3 bigSize = new Vector3(2f,2f,2f);

    public Vector3 targetSize;

    public float sizeTime = 0.5f;
    
    private bool isSmall = false;
    //private bool isNormal = true;
    //private bool isBig = false;

    public void ChangeSmall()
    {
        if (isSmall == false)
        {
            targetSize = smallSize;
            isSmall = true;
        }
        else if (isSmall)
        {
            targetSize = normalSize;
            isSmall = false;
        }

        StartCoroutine(ResizeAnim(targetSize));
        
        //event
        onSizeChange.Invoke();
    }

    private System.Collections.IEnumerator ResizeAnim(Vector3 targetSize)
    {
        Vector3 originalSize = transform.localScale;
        float timePassed = 0f;

        while (timePassed < sizeTime)
        {
            //lerp interpolates size for a basic animation
            transform.localScale = Vector3.Lerp(originalSize, targetSize, timePassed / sizeTime); 
            timePassed += Time.deltaTime;
            yield return null;
        }
        
        transform.localScale = targetSize;
    }
}
