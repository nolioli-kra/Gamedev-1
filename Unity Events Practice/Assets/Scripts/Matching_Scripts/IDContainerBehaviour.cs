using UnityEngine;

public class IDContainerBehaviour : MonoBehaviour
{
    public ID idObject;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(idObject);
    }
}
