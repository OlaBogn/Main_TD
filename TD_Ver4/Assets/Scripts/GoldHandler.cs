using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldHandler : MonoBehaviour
{
    public static int gold;

    [Header("Unity Setup")]
    public Text GoldText;
    public int startgold;



    // StartGold er angitt i unity på hvert level!
    
    // Start is called before the first frame update
    void Start()
    {
        gold = startgold;
        GoldText.text = "$" + gold.ToString();
        InvokeRepeating("UpdateGold", 0f, 0.25f);
    }

    public void UpdateGold()
    {
        GoldText.text = "$" + gold.ToString();

    }
}
