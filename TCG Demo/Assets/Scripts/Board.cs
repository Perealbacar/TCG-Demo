using System.Collections.Generic;
using TCGLogic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public List<GameObject> cardsOnBoard = new List<GameObject>();
    public float cardSpacing = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }  

    public void AddCard(GameObject gameObject)
    {           
        //Instantiate card        
        cardsOnBoard.Add(gameObject);
        gameObject.transform.SetParent(transform);
        UpdateHandVisuals();
    }

    public void RemoveCard(GameObject gameObject)
    {
        cardsOnBoard.Remove(gameObject);
        UpdateHandVisuals();
    }

    private void UpdateHandVisuals()
    {
        int cardCount = cardsOnBoard.Count;
        for (int i = 0; i < cardCount; i++)
        {            
            
            float horizontalOffset = (cardSpacing * (i - (cardCount - 1) / 2f));

            cardsOnBoard[i].transform.localPosition = new Vector3(horizontalOffset, 0f, 0f);
        }
    }
}
