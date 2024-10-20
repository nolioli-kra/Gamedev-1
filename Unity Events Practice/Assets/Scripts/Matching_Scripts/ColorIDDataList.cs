using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ColorIDDataList : ScriptableObject
{
    public List<ColorID> colorIdsList;

    public ColorID currentColor;

    private int num;

    public void SetCurrentColorRandomly()
    {
        num = Random.Range(0, colorIdsList.Count);
        currentColor = colorIdsList[num];
    }
}
