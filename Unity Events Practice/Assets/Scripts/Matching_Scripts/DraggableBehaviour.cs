using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DraggableBehaviour : MonoBehaviour
{
    public UnityEvent OnDragged, endDragged, outOfBounds;
    
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
        if (!IsObjectInView(gameObject))
        {
            outOfBounds.Invoke();
        }
        endDragged.Invoke();
        
        //Debug.Log("Drag stop attempt");
    }

    bool IsObjectInView(GameObject obj)
    {
        Vector3 objPosition = obj.transform.position;
        Vector3 screenPoint = cameraObject.WorldToViewportPoint(objPosition);

        // Check if the object is within the camera's view
        return screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1 && screenPoint.z >= 0;
    }
}
