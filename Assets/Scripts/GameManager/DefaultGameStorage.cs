using System.Collections.Generic;
using System;

public static class DefaultGameStorage
{
    public static List<Enemy> enemyList = new List<Enemy>()
    {
        new Enemy(0.5f,new Tuple<HumourType, HumourType>(HumourType.C,HumourType.D),HumourType.A),
        new Enemy(0.5f,new Tuple<HumourType, HumourType>(HumourType.B,HumourType.D),HumourType.A),
        new Enemy(0.5f,new Tuple<HumourType, HumourType>(HumourType.C,HumourType.B),HumourType.A),
        new Enemy(0.5f,new Tuple<HumourType, HumourType>(HumourType.C,HumourType.D),HumourType.B),
        new Enemy(0.5f,new Tuple<HumourType, HumourType>(HumourType.C,HumourType.A),HumourType.B),
        new Enemy(0.5f,new Tuple<HumourType, HumourType>(HumourType.A,HumourType.D),HumourType.B),
        new Enemy(0.5f,new Tuple<HumourType, HumourType>(HumourType.B,HumourType.D),HumourType.C),
        new Enemy(0.5f,new Tuple<HumourType, HumourType>(HumourType.A,HumourType.D),HumourType.C),
        new Enemy(0.5f,new Tuple<HumourType, HumourType>(HumourType.A,HumourType.B),HumourType.C),
        new Enemy(0.5f,new Tuple<HumourType, HumourType>(HumourType.C,HumourType.A),HumourType.D),
        new Enemy(0.5f,new Tuple<HumourType, HumourType>(HumourType.C,HumourType.B),HumourType.D),
        new Enemy(0.5f,new Tuple<HumourType, HumourType>(HumourType.A,HumourType.B),HumourType.D),
    };

    static HashSet<HumourType> AB = new HashSet<HumourType>() {

        HumourType.A,
        HumourType.B
    };

    static HashSet<HumourType> AC = new HashSet<HumourType>() {

        HumourType.A,
        HumourType.C
    };

    static HashSet<HumourType> AD = new HashSet<HumourType>() {

        HumourType.A,
        HumourType.D
    };

    static HashSet<HumourType> BC = new HashSet<HumourType>() {

        HumourType.C,
        HumourType.B
    };

    static HashSet<HumourType> BD = new HashSet<HumourType>() {

        HumourType.D,
        HumourType.B
    };

    static HashSet<HumourType> CD = new HashSet<HumourType>() {

        HumourType.C,
        HumourType.D
    };

    static HashSet<HumourType> ABC = new HashSet<HumourType>() {

        HumourType.A,
        HumourType.B,
        HumourType.C
    };

    static HashSet<HumourType> ABD = new HashSet<HumourType>() {

        HumourType.A,
        HumourType.B,
        HumourType.D
    };

    static HashSet<HumourType> ACD = new HashSet<HumourType>() {

        HumourType.A,
        HumourType.C,
        HumourType.D
    };

    static HashSet<HumourType> BCD = new HashSet<HumourType>() {

        HumourType.C,
        HumourType.B,
        HumourType.D
    };

    static HashSet<HumourType> super = new HashSet<HumourType>() {
        HumourType.A,
        HumourType.C,
        HumourType.B,
        HumourType.D
    };


    public static List<Card> GameCards = new List<Card>() {

        new Card("Porque é que a galinha atravessou a estrada?", -1, AB, -1, "Para ir para o outro lado da rua!", ShopType.Basic),
        new Card("De que cor é o cavalo branco de napoleão", -1, AB, -1, "...", ShopType.Basic),
        new Card("Qual é o título de uma notícia em que uma baleia mata outra a tiro?", -1, AC, -1, "Baleia baleia baleia.", ShopType.Basic),
        new Card("Como é que se chama um cão sem patas?", -1, AC, -1, "Não se chama vai se buscar.", ShopType.Basic),
        new Card("Como é que se chama o protagonista do Dragon Ball com hemorroidas", -1, AD, -1, "San grocu.", ShopType.Basic),
        new Card("truz-truz!", -1, AD, -1, "Quem é?\ntruz-truz!\nQuem é?\ntruz-truz!\nQuem é?...", ShopType.Basic),
        new Card("Porque é que o peiDe congelado é mais caro que o peiDe fresco?", -1, BC, -1,
            "Porque o peiDe congelado inclui a sobremesa.", ShopType.Basic),
        new Card("O que é que o Kurt Cobain e o Michaelangelo têm em comum?", -1, BC, -1,
            "Ambos usaram o seu cerebro para pintar o teto", ShopType.Basic),
        new Card("Conversa entre dois licenciados", -1, BD, -1, "-Era um BigMac por favor", ShopType.Basic),
        new Card("Havia um cão que respirava pelo cu.", -1, BD, -1, "Sentou-se e morreu", ShopType.Basic),
        new Card("O que fazem duas cenouras a discutir?", -1, CD, -1, "Poluição cenoura", ShopType.Basic),
        new Card("-Vamos comer crianças!", -1, CD, -1, "-Vamos comer, crianças!\nUsem virgulas e salvem vidas!", ShopType.Basic),
        /*new Card("Quantos bebés são precisos para mudar a luz da minha cave?", -1, ABC, -1, 
            "Aparentemente mais que vinte porque a minha cave continua às escuras", ShopType.Special),
        new Card("O que é que acontece quando misturas adn de tigre com adn humano", -1, ABC, -1,
            "És eDpulso do jardim zoológico", ShopType.Special),*/
        new Card("", -1, ABD, -1, "desc15", ShopType.Special),
        new Card("carta16", -1, ABD, -1, "desc16", ShopType.Special),
        new Card("carta17", -1, ACD, -1, "desc17", ShopType.Special),
        new Card("carta18", -1, ACD, -1, "desc18", ShopType.Special),
        new Card("carta19", -1, BCD, -1, "desc19", ShopType.Special),
        new Card("carta20", -1, BCD, -1, "desc20", ShopType.Special),
        new Card("", -1, super, -1, "", ShopType.Super)

    };


}