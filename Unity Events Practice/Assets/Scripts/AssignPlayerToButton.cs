using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AssignPlayerToButton : MonoBehaviour
{
    public Button sizeChangeButton;

    void Start()
    {
        StartCoroutine(DelayedStart(0.7f));
    }

    private IEnumerator DelayedStart(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        
        //find player by tag
        GameObject playerInScene = GameObject.FindGameObjectWithTag("Player");

        if (playerInScene != null)
        {
            SizeButton sizeButton = playerInScene.GetComponent<SizeButton>();

            if (sizeButton != null)
            {
                // Clear any existing listeners and add the new one
                sizeChangeButton.onClick.RemoveAllListeners();
                sizeChangeButton.onClick.AddListener(sizeButton.ChangeSmall);

                Debug.Log("Size change function assigned successfully.");
            }
            else
            {
                Debug.LogError("SizeButton component not found on player.");
            }
        }
        else
        {
            Debug.LogError("Player not found in the scene.");
        }
    }
}
