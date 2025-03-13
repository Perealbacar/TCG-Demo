using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TCGLogic;

public class HandManager : MonoBehaviour
{
    //public for a more easy way of customizing from inspector for prototyping.
    public DeckManager deckManager;
    public GameObject cardPrefab; 
    public Transform handTransform;
    public float cardRotation = 7.5f;
    public float cardSpacing = 100f;
    public List<GameObject> cardsInHand = new List<GameObject>();// List of the card objects in our hand.
    public int handSize = 6;
    // Start is called before the first frame update
    void Start()
    {
        InitializeHand();
    }

    private void InitializeHand()
    {
        for (int i = 0; i < handSize; i++) 
        {
            //AddCardToHand();
        }

    }
    public void AddCardToHand(Card cardData)
    {
        //Instantiate card

        GameObject newCard = Instantiate(cardPrefab, handTransform.position, Quaternion.identity, handTransform);
        cardsInHand.Add(newCard);

        // Set the CardData of the instantiated card
        newCard.GetComponent<CardVisuals>().cardData = cardData;
        
        UpdateHandVisuals();
    }

    private void UpdateHandVisuals()
    {
        int cardCount = cardsInHand.Count;
        for (int i = 0; i < cardCount; i++)
        {
            float rotationAngle = (cardRotation * (i - (cardCount - 1) / 2f));
            cardsInHand[i].transform.localRotation = Quaternion.Euler(0f, 0f, rotationAngle);
            float horizontalOffset = (cardSpacing * (i - (cardCount - 1) / 2f));

            cardsInHand[i].transform.localPosition = new Vector3(horizontalOffset, 0f, 0f);
        }
    }
}
