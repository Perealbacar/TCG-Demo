using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TCGLogic;
using TMPro;
using UnityEngine.UI;

public class CardVisuals : MonoBehaviour
{

    public Card cardData;

    public Image cardImage;
    public TMP_Text nameText;
    public TMP_Text healthText;
    public int health;
    public int damage;
    public TMP_Text damageText;
    public TMP_Text rarityText;
    
    // Start is called before the first frame update
    void Start()
    {
        health = cardData.health;
        damage = cardData.damage;
        UpdateCardDisplay();
    }

    public void UpdateCardDisplay()
    {
        nameText.text = cardData.cardName;
        cardImage.sprite = cardData.cardSprite;
        healthText.text = health.ToString();
        damageText.text = damage.ToString();
        rarityText.text = cardData.cardRarity.ToString();

    }
}
