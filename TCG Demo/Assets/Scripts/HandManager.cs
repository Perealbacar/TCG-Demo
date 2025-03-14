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
    public float verticalSpacing = 100f;
    public int maxHandSize = 6;
    public List<GameObject> cardsInHand = new List<GameObject>();// List of the card objects in our hand.
    public BoardManager boardManager;
    
    // Start is called before the first frame update
    void Start()
    {
        InitializeHand();
    }

    private void InitializeHand()
    {
        for (int i = 0; i < maxHandSize; i++) 
        {
            //AddCardToHand();
        }

    }
    public void AddCardToHand(Card cardData)
    {
        if(cardsInHand.Count < maxHandSize)
        {        
        //Instantiate card

        GameObject newCard = Instantiate(cardPrefab, handTransform.position, Quaternion.identity, handTransform);
        cardsInHand.Add(newCard);

        // Set the CardData of the instantiated card
        newCard.GetComponent<CardVisuals>().cardData = cardData;
            CardMovement cardMovement = newCard.GetComponent<CardMovement>();
            cardMovement.handManager = this;
        
        }
        UpdateHandVisuals();
    }

    public void RemoveCard(GameObject gameObject)
    {
        cardsInHand.Remove(gameObject);
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
