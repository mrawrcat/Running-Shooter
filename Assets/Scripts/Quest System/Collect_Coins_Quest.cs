using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect_Coins_Quest : Quest
{
    void Start()
    {
        Quest_Description = "Collect 5 Coins";

        Goals.Add(new Collect_Goal(this, "Coin", "Collect 5 Coins", false, 0, 5));

        Goals.ForEach(g => g.Init());
    }
}
