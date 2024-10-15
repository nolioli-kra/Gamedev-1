using System.Globalization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextLabelBehavior : MonoBehaviour
{
    private Text label;
    public UnityEvent startEvent;
    void Start()
    {
        label = GetComponent<Text>();
        startEvent.Invoke();
    }
    
    public void UpdateLabel(FloatData dataObj)
    {
        label.text = dataObj.floatValue.ToString(CultureInfo.InvariantCulture);
    }

    public void UpdateLabel(IntData dataObj)
    {
        label.text = dataObj.intValue.ToString(CultureInfo.InvariantCulture);
    }
}
