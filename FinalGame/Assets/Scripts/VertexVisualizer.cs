using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class VertexVisualizer : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null) return;

        Mesh mesh = meshFilter.sharedMesh;
        if (mesh == null) return;

        // Get the vertices in local space
        Vector3[] vertices = mesh.vertices;

        // Draw each vertex as a small sphere in the Scene view
        Gizmos.color = Color.yellow;
        foreach (Vector3 vertex in vertices)
        {
            Vector3 worldPos = transform.TransformPoint(vertex);
            Gizmos.DrawSphere(worldPos, 0.01f);  // Adjust size as needed
        }
    }
}

