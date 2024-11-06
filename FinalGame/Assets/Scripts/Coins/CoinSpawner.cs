using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public VectorLocation coinPositions;
    
    void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        Quaternion coinRotation = Quaternion.Euler(0, 0, 0);
        
        foreach (var position in coinPositions.positions)
        {
            Instantiate(coinPrefab, position, coinRotation);
            Debug.Log("coin spawned at " + position.ToString());
        }
    }
}
