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
    }

    public void ChangeRendererColor(ColorID colorID)
    {
        if (colorID != null)
        {
            objMaterial.color = colorID.value;
            Debug.Log("color applied");
        }
    }
}
