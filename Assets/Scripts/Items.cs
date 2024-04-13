using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Items
{
    public ItemInfo[] items;

    public int GetRandomItemIndex()
    {
        float num = UnityEngine.Random.value;
        if (num >= 0 && num < 0.4)
            return 0; //rock
        else if (num >= 0.4 && num < 0.5)
            return 1; //bomb
        else if (num >= 0.5 && num < 0.6)
            return 2; // diamond
        else if (num >= 0.6 && num < 0.725)
            return 3; // emerald
        else if (num >= 0.725 && num < 0.85)
            return 4; // ruby
        else if (num >= 0.85 && num < 0.95)
            return 5; // pearl
        else if (num >= 0.95 && num <= 1)
            return 6; // golden monkey
        else return 0;

    }
}