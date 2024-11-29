using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AiSpeak : MonoBehaviour
{
    public Text aiDialogue;
    public int displayDuration;

    public void ApproachText()
    {
        ShowDialogue("You can't have my key!");
    }
    
    private void ShowDialogue(string message)
    {
        if (aiDialogue != null)
        {
            aiDialogue.text = message; // Set the dialogue text
            aiDialogue.gameObject.SetActive(true); // Ensure it's visible
            StartCoroutine(HideDialogueAfterDelay());
        }
    }
    
    private IEnumerator HideDialogueAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration); // Wait for the duration
        if (aiDialogue != null)
        {
            aiDialogue.gameObject.SetActive(false); // Hide the text
        }
    }
}
