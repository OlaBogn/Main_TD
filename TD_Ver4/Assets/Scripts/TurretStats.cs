using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretStats : MonoBehaviour
{
    public float[] stats;
    public static float[] test;

    public Text dmgTxt, rangeTxt, rateTxt;
    public GameObject StatPanel;
    public GameObject BtnPanel;


    // Range, FireRate, Damage
    public void GetStats(float[] n)
    {
        StatPanel.gameObject.SetActive(true);
        BtnPanel.gameObject.SetActive(true);


        Debug.Log("It worked");
        Debug.Log(n[0]);
        rangeTxt.text = "Range: " + n[0].ToString();
        rateTxt.text = "Fire Rate: " + n[1].ToString();
        dmgTxt.text = "Damage: " + n[2].ToString();
    }


    public void ClearStats()
    {
        StatPanel.gameObject.SetActive(false);
        BtnPanel.gameObject.SetActive(false);

    }

}
