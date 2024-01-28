using System;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static ShopType? currentShopType = null;
    public static int currentShopLoopFrame = 0;
    public static Player player = new Player();
    


    static HashSet<HumourType> AB = new HashSet<HumourType>() {

        HumourType.Banana,
        HumourType.Intelligent
    };

    static HashSet<HumourType> AC = new HashSet<HumourType>() {

        HumourType.Banana,
        HumourType.Dark
    };

    static HashSet<HumourType> AD = new HashSet<HumourType>() {

        HumourType.Banana,
        HumourType.x
    };

    static HashSet<HumourType> BC = new HashSet<HumourType>() {

        HumourType.Dark,
        HumourType.Intelligent
    };

    static HashSet<HumourType> BD = new HashSet<HumourType>() {

        HumourType.x,
        HumourType.Intelligent
    };

    static HashSet<HumourType> CD = new HashSet<HumourType>() {

        HumourType.Dark,
        HumourType.x
    };

    static HashSet<HumourType> ABC = new HashSet<HumourType>() {

        HumourType.Banana,
        HumourType.Intelligent,
        HumourType.Dark
    };

    static HashSet<HumourType> ABD = new HashSet<HumourType>() {

        HumourType.Banana,
        HumourType.Intelligent,
        HumourType.x
    };

    static HashSet<HumourType> ACD = new HashSet<HumourType>() {

        HumourType.Banana,
        HumourType.Dark,
        HumourType.x
    };

    static HashSet<HumourType> BCD = new HashSet<HumourType>() {

        HumourType.Dark,
        HumourType.Intelligent,
        HumourType.x
    };

    static HashSet<HumourType> super = new HashSet<HumourType>() {
        HumourType.Banana,
        HumourType.Dark,
        HumourType.Intelligent,
        HumourType.x
    };


    /**
     * 
     * A - banana
     * B - Intelligent
     * C - Dark
     * D - dad jokes
     *
     */

    public static List<Card> GameCards = new List<Card>() {

        new Card("Porque é que a galinha atravessou a estrada?", -1, AB, -1, "Para ir para o outro lado da rua!", ShopType.Basic),
        new Card("De que cor é o cavalo branco de napoleão", -1, AB, -1, "...", ShopType.Basic),
        new Card("O humor desta piada era tão negro...", -1, AC, -1, "...que infelizmente foi baleada pela policia", ShopType.Basic),
        new Card("Qual a diferença entre um padre e um tenista?", -1, AC, -1, "As bolas com que o tenista brinca têm pelinhos.", ShopType.Basic),
        new Card("Como é que se chama o protagonista do Dragon Ball com hemorroidas", -1, AD, -1, "San grocu", ShopType.Basic),
        new Card("truz-truz!", -1, AD, -1, "Quem é?\ntruz-truz!\nQuem é?\ntruz-truz!\nQuem é?...", ShopType.Basic),
        new Card("Esta piada era suposta ser humor negro e inteligente.", -1, BC, -1,
            "Infelizmente são duas coisas coisas que não combinam", ShopType.Basic),
        new Card("O que é que o Kurt Cobain e o Michaelangelo têm em comum?", -1, BC, -1,
            "Ambos usaram o seu cerebro para pintar o teto", ShopType.Basic),
        new Card("Conversa entre dois licenciados", -1, BD, -1, "-Era um BigMac por favor", ShopType.Basic),
        new Card("carta10", -1, BD, -1, "desc10", ShopType.Basic),
        new Card("Qual é a parte mais dificil de comer num vegetal?", -1, CD, -1, "A cadeira de rodas", ShopType.Basic),
        new Card("O que é pior que um bebé dentro de um caixote do lixo?", -1, CD, -1, "Um bebé dentro de dois", ShopType.Basic),
        new Card("Quantos bebés são precisos para mudar a luz da minha cave?", -1, ABC, -1, "Aparentemente mais que vinte porque a minha cave continua às escuras", ShopType.Special),
        new Card("O que é que acontece quando misturas adn de tigre com adn humano", -1, ABC, -1,
            "És expulso do jardim zoológico", ShopType.Special),
        new Card("carta15", -1, ABD, -1, "desc15", ShopType.Special),
        new Card("carta16", -1, ABD, -1, "desc16", ShopType.Special),
        new Card("carta17", -1, ACD, -1, "desc17", ShopType.Special),
        new Card("carta18", -1, ACD, -1, "desc18", ShopType.Special),
        new Card("carta19", -1, BCD, -1, "desc19", ShopType.Special),
        new Card("carta20", -1, BCD, -1, "desc20", ShopType.Special),
        new Card("Cópia Barata do Especial do Dave Chapelle", -1, super, -1, "Acabou-se a inspiração", ShopType.Super)

    };



    public static void ResetShopType()
    {
        currentShopType = null;
    }

    public static void StartNewGame()
    {
        player = new Player();
    }

    internal static List<Card> GetCards(ShopType? currentShopType)
    {
        List<Card> cards = new List<Card>();
        if (currentShopType == null)
            return cards;

        foreach (Card card in DefaultGameStorage.cardList)
        {
            if (player.GetInventory().Contains(card) || player.GetHand().Contains(card))
                continue;
            if (card.GetCardType() != currentShopType) 
                continue;

            cards.Add(card);
        }

        return cards;
    }
}