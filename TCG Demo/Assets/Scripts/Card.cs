using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TCGLogic
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Card")]
    public class Card : ScriptableObject
    {
        public string cardName;
        public CardRarity cardRarity;
        public int health;
        public int damage;

        public enum CardRarity
        {
            Common,
            Rare,
            Epic,
            Legend
        }
        
    }
}