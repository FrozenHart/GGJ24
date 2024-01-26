using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private int mana = 7;
    private List<string> hand = new List<string>();
    private Dictionary<string, Card> inventory = new Dictionary<string,Card>();
    private List<string> deck = new List<string>();
    private List<Effects> effects = new List<Effects>();

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
            int cardNumber = Random.Range(0, deck.Count - 1);
            hand.Add(deck[cardNumber]);
            deck.RemoveAt(cardNumber);
        }
    }
}
