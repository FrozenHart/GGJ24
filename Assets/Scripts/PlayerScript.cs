using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private int Mana = 7;
    private List<string> Hand = new List<string>();
    private Dictionary<string, Card> Inventory = new Dictionary<string,Card>();
    private List<string> Deck = new List<string>();
    private List<Effects> Effects = new List<Effects>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DrawCard(int numberOfCards)
    {
        for (int i = 0; i < numberOfCards; i++)
        {
            int cardNumber = Random.Range(0, Deck.Count - 1);
            Hand.Add(Deck[cardNumber]);
            Deck.RemoveAt(cardNumber);
        }
    }
}
