using UnityEngine;
using System.Collections.Generic;
using TCGLogic;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BoardManager playerBoard;
    [SerializeField] private BoardManager enemyBoard;
    [SerializeField] private DeckManager deckManager;
    [SerializeField] private HandManager enemyHand;
    [SerializeField] private int playerHealth = 20;
    public TextMeshProUGUI playerHealthText;
    [SerializeField] private int enemyHealth = 20;
    public TextMeshProUGUI enemyHealthText;

    private bool isPlayerTurn = true;

    public void EndTurn()
    {
        if (isPlayerTurn)
        {
            ResolveTurn(playerBoard, enemyBoard, ref enemyHealth, enemyHealthText);
            isPlayerTurn = false;
            EnemyTurn();
        }
    }

    private void EnemyTurn()
    {
        //deckManager.DrawCard(enemyHand);
        if (enemyBoard.cardsOnBoard.Count == 0 && enemyHand.cardsInHand.Count > 0)
        {
            GameObject playedCard = enemyHand.cardsInHand[0];
            enemyHand.cardsInHand.Remove(playedCard);
            enemyBoard.AddCard(playedCard);
        }
        ResolveTurn(enemyBoard, playerBoard, ref playerHealth, playerHealthText);
        isPlayerTurn = true;
    }

    private void ResolveTurn(BoardManager attackingBoard, BoardManager defendingBoard, ref int defenderHealth, TextMeshProUGUI defenderHealthText)
    {
        List<GameObject> attackingCards = new List<GameObject>(attackingBoard.cardsOnBoard);
        List<GameObject> defendingCards = new List<GameObject>(defendingBoard.cardsOnBoard);

        foreach (GameObject card in attackingCards)
        {
            if (card == null) continue;
            CardVisuals cardComponent = card.GetComponent<CardVisuals>();
            if (cardComponent == null) continue;

            if (defendingCards.Count == 0)
            {
                defenderHealth -= cardComponent.cardData.damage;
                defenderHealthText.text = defenderHealth.ToString();
                Debug.Log("Direct damage: " + cardComponent.cardData.damage);
            }
            else
            {
                GameObject targetCard = defendingCards[0];
                if (targetCard == null) continue;

                CardVisuals targetComponent = targetCard.GetComponent<CardVisuals>();
                if (targetComponent == null) continue;

                targetComponent.health -= cardComponent.cardData.damage;
                Debug.Log("Card attacked: " + targetComponent.health + " health left");
                targetComponent.UpdateCardDisplay();

                if (targetComponent.health <= 0)
                {
                    defendingBoard.RemoveCard(targetCard);
                    Destroy(targetCard);
                    defendingCards.RemoveAt(0); // Ensure the list is updated to avoid using destroyed objects
                }
            }
        }
    }
}
