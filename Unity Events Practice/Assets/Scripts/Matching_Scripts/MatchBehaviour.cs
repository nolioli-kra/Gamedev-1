using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MatchBehaviour : MonoBehaviour
{
    public ColorID idObject;
    public UnityEvent matchedEvent, noMatchedEvent, onAwake, noMatchDelayedEvent;

    private void Start()
    {
        onAwake.Invoke();
    }

    public void OnColorReceived(ColorID colorID)
    {
        idObject = colorID;
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        var tempObject = other.GetComponent<MatchBehaviour>();
        if (tempObject == null)
        {
            yield break;
        }
        
        var otherID = tempObject.idObject;
        if (otherID != null)
        {
            if (otherID == idObject)
            {
                matchedEvent.Invoke();
                Debug.Log("Matched!");
            }
            else
            {
                noMatchedEvent.Invoke();
                yield return new WaitForSeconds(0.5f);
                noMatchDelayedEvent.Invoke();
                Debug.Log("No Match");
            }
        }
    }
}
