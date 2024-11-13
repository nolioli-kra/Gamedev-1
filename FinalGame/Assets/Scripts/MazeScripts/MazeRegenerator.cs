using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoudiniEngineUnity;

public class MazeRegenerator : MonoBehaviour
{
    public HEU_HoudiniAsset houdiniAsset; // Reference to your Houdini asset
    public string seedParameterName = "GlobalSeed"; // Name of the parameter to modify

    public void GenerateNewMaze()
    {
        if (houdiniAsset == null)
        {
            Debug.LogError("Houdini Asset not assigned!");
            return;
        }

        // Get the parameters object from the Houdini asset
        HEU_Parameters parameters = houdiniAsset.Parameters;

        if (parameters == null)
        {
            Debug.LogError("Parameters object not found on Houdini asset!");
            return;
        }

        // Set the seed parameter
        float newSeed = Random.Range(0, int.MaxValue);
        bool success = parameters.SetFloatParameterValue(seedParameterName, newSeed);

        if (!success)
        {
            Debug.LogError($"Failed to set parameter '{seedParameterName}' on Houdini asset!");
            return;
        }

        // Cook the asset to apply the changes
        houdiniAsset.RequestCook(true, false, true, true);

        Debug.Log($"Maze regenerated with new seed: {newSeed}");
    }

    void LogParameters()
    {
        if (houdiniAsset == null) return;

        HEU_Parameters parameters = houdiniAsset.Parameters;

        if (parameters == null)
        {
            Debug.LogError("No parameters found!");
            return;
        }

        foreach (var parameter in parameters.GetParameters())
        {
            Debug.Log($"Parameter Name: {parameter._name}, Type: {parameter._fileTypeInfo}");
        }
    }

}
