using UnityEngine;
using UnityEngine.Events;

public class GameActionHandler : MonoBehaviour
{
    public GameAction gameActionObject;
    public UnityEvent onRaiseEvent;

    private void Start()
    {
        gameActionObject.raise += Raise;
    }

    private void Raise()
    {
        onRaiseEvent.Invoke();
    }
}
