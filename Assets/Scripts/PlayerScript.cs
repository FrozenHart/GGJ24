using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private int mana=7;
    private List<string> hand = new List<string>();
    private Dictionary<string,Card> inventory = new Dictionary<string,Card>();
    private List<string> Deck = new List<string>();
    private List<Efects> efects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Draw_card(int number_of_cards)
    {
        for (int i = 0; i < number_of_cards; i++)
        {
            int card_number = Random.Range(0, Deck.Count - 1);
            hand.Add(Deck[card_number]);
            Deck.RemoveAt(card_number);
        }
    }
}
