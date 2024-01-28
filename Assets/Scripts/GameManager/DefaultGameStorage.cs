using System.Collections.Generic;
using System;
using System.Security.Cryptography;

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

    #region
    public static HashSet<HumourType> AB = new HashSet<HumourType>() {

        HumourType.A,
        HumourType.B
    };

    public static HashSet<HumourType> AC = new HashSet<HumourType>() {

        HumourType.A,
        HumourType.C
    };

    public static HashSet<HumourType> AD = new HashSet<HumourType>() {

        HumourType.A,
        HumourType.D
    };

    public static HashSet<HumourType> BC = new HashSet<HumourType>() {

        HumourType.C,
        HumourType.B
    };

    public static HashSet<HumourType> BD = new HashSet<HumourType>() {

        HumourType.D,
        HumourType.B
    };

    public static HashSet<HumourType> CD = new HashSet<HumourType>() {

        HumourType.C,
        HumourType.D
    };

    public static HashSet<HumourType> ABC = new HashSet<HumourType>() {

        HumourType.A,
        HumourType.B,
        HumourType.C
    };

    public static HashSet<HumourType> ABD = new HashSet<HumourType>() {

        HumourType.A,
        HumourType.B,
        HumourType.D
    };

    public static HashSet<HumourType> ACD = new HashSet<HumourType>() {

        HumourType.A,
        HumourType.C,
        HumourType.D
    };

    public static HashSet<HumourType> BCD = new HashSet<HumourType>() {

        HumourType.C,
        HumourType.B,
        HumourType.D
    };

    public static HashSet<HumourType> super = new HashSet<HumourType>() {
        HumourType.A,
        HumourType.C,
        HumourType.B,
        HumourType.D
    };
    #endregion

    public static List<Card> GameCards = new List<Card>() {

        new Card("Why did the chicken cross the road?", -1, AB, 0.1f, "To get to the other side!", ShopType.Basic),
        new Card("Did you know that if your feet smell and your nose runs...", -1, AB, 0.1f, "...you're built updside down!", ShopType.Basic),
        new Card("Sometimes i relate to fortnite...", -1, AC, 0.1f, "...I know how it is to only get played by 12y olds.", ShopType.Basic),
        new Card("Just met Darth Vader's corrupt cousin.", -1, AC, 0.1f, "Taxi Vader.", ShopType.Basic),
        new Card("Why did the tomato turn red?", -1, AD, 0.1f, "It saw the sallad dressing.", ShopType.Basic),
        new Card("What did the \"p\" say to the \"q\"?", -1, AD, 0.1f, "Who the fuck put a mirror in front of me!?", ShopType.Basic),
        new Card("Knock-knock!", -1, BC, 0.1f,
            "Who's there? Knock-knock! Who's there? Knock-knock! Who's there? Knock-knock!...", ShopType.Basic),
        new Card("Did an air guitar at a party last week...", -1, BC, 0.1f,
            "The mime next door came around to complain.", ShopType.Basic),
        new Card("What do sea monsters eat", -1, BD, 0.1f, "Fish and ships", ShopType.Basic),
        new Card("Sex is my Cardio...", -1, BD, 0.1f, "That explains why I'm still fat", ShopType.Basic),
        new Card("What's red and bad for your teeth?", -1, CD, 0.1f, "A brick!", ShopType.Basic),
        new Card("What's red and hurts when thrown at you?", -1, CD, 0.1f, "A brick!", ShopType.Basic),
        new Card("I hate 9/11 jokes...", -1, ABC, 0.1f, "They always crash and burn.", ShopType.Special),
        new Card("Why does 10 have PTSD", -1, ABC, 0.1f, "It was in the middle of 9 and 11", ShopType.Special),
        new Card("I have a logic fetish...", -1, ABD, 0.1f, "I just can't coming to conclusions", ShopType.Special),
        new Card("I would make a gay joke...", -1, ABD, 0.1f, "Butt fuck it.", ShopType.Special),
        new Card("I just farted in my wallet...", -1, ACD, 0.1f, "Now i have Gas money.", ShopType.Special),
        new Card("Most people have 32 teeth...", -1, ACD, 0.1f, "Some have 4, it's just simply meth.", ShopType.Special),
        new Card("I just discovered I have low IQ...", -1, BCD, 0.1f, "I was dumbfounded!", ShopType.Special),
        new Card("Why is the sun so smart...", -1, BCD, 0.1f, "It has a lot of degrees!", ShopType.Special),
        new Card("", -1, super, 0.1f, "", ShopType.Super)

    };


}