using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TCGLogic;

public class DeckManager : MonoBehaviour
{
    public List<Card> allCards = new List<Card>();
    private int currentIndex = 0;
    private int deckSize = 20;
    private int commonCards = 8;
    private int rareCards = 6;
    private int epicCards = 4;
    private int legendCards = 2;

    public Card commonCard;
    public Card rareCard;
    public Card epicCard;
    public Card legendCard;

    public void Start()
    {
        PopulateDeck();

        HandManager hand = FindObjectOfType<HandManager>();
        for(int i = 0; i < 6; i++)
        {
            DrawCard(hand);
        }
    }
    public void DrawCard(HandManager handManager)
    {
        if (allCards.Count == 0)
        {
            Debug.Log("There are no cards left in the Deck!");
            return;
        }

        Card nextCard = allCards[currentIndex];
        handManager.AddCardToHand(nextCard);
        currentIndex = (currentIndex +1) % allCards.Count;        
    }

    public void PopulateDeck()
    {
        allCards.Clear(); // Clear the deck before populating

        // Add the specified number of each rarity
        for (int i = 0; i < legendCards; i++)
        {
            allCards.Add(legendCard);
        }
        for (int i = 0; i < epicCards; i++)
        {
            allCards.Add(epicCard);
        }
        for (int i = 0; i < rareCards; i++)
        {
            allCards.Add(rareCard);
        }
        for (int i = 0; i < commonCards; i++)
        {
            allCards.Add(commonCard);
        }

        // Ensure deck has exactly 'deckSize' cards (fallback for miscalculations)
        while (allCards.Count < deckSize)
        {
            allCards.Add(commonCard); // Fill any remaining spots with common cards
        }

        ShuffleDeck(); // Shuffle after populating
        Debug.Log("Deck populated and shuffled!");
    }


    public void ShuffleDeck()
    {        
        System.Random rng = new System.Random();
        int n = allCards.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1); // Get a random index from 0 to i
            (allCards[i], allCards[j]) = (allCards[j], allCards[i]); // Swap elements
        }

        Debug.Log("Deck shuffled!");
       
    }

}
