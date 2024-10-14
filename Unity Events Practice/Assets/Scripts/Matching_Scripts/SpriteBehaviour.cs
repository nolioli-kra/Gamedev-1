using System;
using UnityEngine;


[RequireComponent(typeof(MeshRenderer))]
public class SpriteBehaviour : MonoBehaviour
{
    private MeshRenderer objRenderer;
    
    public Material objMaterial;

    private void Start()
    {
        objRenderer = GetComponent<MeshRenderer>();
        objMaterial = objRenderer.material;
        Debug.Log("material acquired:" + objMaterial);
    }

    public void ChangeRendererColor(ColorID colorID)
    {
        WaitForSeconds wait = new WaitForSeconds(0.1f);
        if (colorID != null)
        {
            objMaterial.color = colorID.value;
            Debug.Log("color applied");
        }
    }
}
