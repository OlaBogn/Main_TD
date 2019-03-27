﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldHandler : MonoBehaviour
{
    public Text GoldText;
    public static int gold;
    public int startgold;

    // StartGold er angitt i unity på hvert level!

    // Start is called before the first frame update
    void Start()
    {
        gold = startgold;
        GoldText.text = "$" + gold.ToString();
    }

    public void UpdateGold()
    {
        GoldText.text = "$" + gold.ToString();

    }
}
