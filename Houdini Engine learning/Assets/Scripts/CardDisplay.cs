using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public Card newCard;
    
    public TextMeshProUGUI cardText;
    public TextMeshProUGUI descriptionText;

    public Image cardArtwork;

    public TextMeshProUGUI manaText;
    
    // Start is called before the first frame update
    void Start()
    {
        newCard.PrintName();
        
        cardText.text = newCard.name;
        descriptionText.text = newCard.description;
        
        cardArtwork.sprite = newCard.artwork;
        
        manaText.text = newCard.manaCost.ToString();
    }
    
}
