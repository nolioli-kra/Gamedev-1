using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]
public class SpriteBehaviour : MonoBehaviour
{
    private MeshRenderer objRenderer;
    public Material objMaterial;
    public float delay = 0;
    public ColorID currentColorID;

    public UnityEvent<ColorID> onColorIDChanged;

    public MatchBehaviour matchBehaviour;

    private void Start()
    {
        objRenderer = GetComponent<MeshRenderer>();
        objMaterial = objRenderer.material;
        //Debug.Log("material acquired:" + objMaterial);
    }

    //method to start delayed change
    public void StartDelayedChange(ColorIDDataList colorIDList)
    {
        StartCoroutine(DelayedChange(colorIDList));
    }
    
    

    //coruotine to delay based on time variable
    private IEnumerator DelayedChange(ColorIDDataList colorIDList)
    {
        yield return new WaitForSeconds(delay);
        ChangeRendererColorFromList(colorIDList);

        if (matchBehaviour != null)
        {
            matchBehaviour.idObject = currentColorID;
        }
    }
    
    private void ChangeRendererColorFromList(ColorIDDataList colorIDList)
    {
        
        if (colorIDList == null)
        {
            Debug.LogError("ColorIDDataList is null!");
            return;
        }

        if (colorIDList.currentColor == null)
        {
            Debug.LogError("ColorIDDataList's currentColor is null!");
            return;
        }
        
        objMaterial.color = colorIDList.currentColor.value;
        currentColorID = (ColorID)colorIDList.currentColor;
        //Debug.Log("assigned currentcolorID: " + currentColorID);
        //onColorIDChanged.Invoke(currentColorID);
    }
    
}
