using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public UnityEvent DoorOpened;
    public PlayerBool hasKey;
    
    public Text dialogueText;
    public Animator doorAnimator;
    public float displayDuration = 3f;

    public void UnlockDoor()
    {
        if (hasKey.playerBool == true)
        {
            DoorOpened.Invoke();
            doorAnimator.SetTrigger("DoorOpened");
            ShowDialogue("Door unlocked!");
            Debug.Log("Door unlocked!");
        }
        else
        {
            ShowDialogue("You do not have the key.");
            Debug.Log("You do not have the key.");
        }
    }

    private void ShowDialogue(string message)
    {
        if (dialogueText != null)
        {
            dialogueText.text = message; // Set the dialogue text
            dialogueText.gameObject.SetActive(true); // Ensure it's visible
            StartCoroutine(HideDialogueAfterDelay());
        }
    }
    
    private IEnumerator HideDialogueAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration); // Wait for the duration
        if (dialogueText != null)
        {
            dialogueText.gameObject.SetActive(false); // Hide the text
        }
    }
}
