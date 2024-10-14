using System;
using UnityEngine;
using UnityEngine.Events;

public class MatchBehaviour : MonoBehaviour
{
    public ID idObject;
    public UnityEvent matchedEvent, noMatchedEvent, onAwake;

    private void Start()
    {
        onAwake.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        var tempObject = other.GetComponent<MatchBehaviour>();
        if (tempObject == null)
        {
            return;
        }
        
        var otherID = tempObject.idObject;
        if (otherID != null)
        {
            if (otherID == idObject)
            {
                matchedEvent.Invoke();
                //Debug.Log("Matched!");
            }
            else
            {
                noMatchedEvent.Invoke();
                //Debug.Log("No Match");
            }
        }
    }
}
