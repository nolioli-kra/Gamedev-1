using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class SpriteBehaviour : MonoBehaviour
{
    private MeshRenderer objRenderer;
    public Material objMaterial;
    public float delay = 0;

    private void Start()
    {
        objRenderer = GetComponent<MeshRenderer>();
        objMaterial = objRenderer.material;
        Debug.Log("material acquired:" + objMaterial);
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
    }

    /*
    public void ChangeRendererColor(ColorID colorID)
    {
        if (colorID != null)
        {
            Debug.Log("applying color:" + colorID.value);
            objMaterial.color = colorID.value;
            Debug.Log("color applied");
        }
    }
    
    
    public void ChangeRendererColorFromList(ColorIDDataList colorIDList)
    {
        objMaterial.color = colorIDList.currentColor.value;
        Debug.Log("Color applied successfully");
    }
    */

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

        // If both checks pass, apply the color
        Debug.Log("Applying color: " + colorIDList.currentColor.value);
        objMaterial.color = colorIDList.currentColor.value;
        Debug.Log("Color applied successfully");
    }
}
