using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DraggableBehaviour : MonoBehaviour
{
    public UnityEvent OnDragged, endDragged;
    
    public Camera cameraObject;

    public bool draggable;
    public Vector2 position;

    public void GetCamera()
    {
        cameraObject = Camera.main;
        Debug.Log("Camera found");
    }
    
    public IEnumerator OnMouseDown()
    {
        draggable = true;
        OnDragged.Invoke();

        while (draggable)
        {
            yield return new WaitForFixedUpdate();
            //Debug.Log("Drag attempt");
            position = cameraObject.ScreenToWorldPoint(Input.mousePosition);
            
            transform.position = position;
        }
    }

    private void OnMouseUp()
    {
        draggable = false;
        endDragged.Invoke();
        //Debug.Log("Drag stop attempt");
    }
}
