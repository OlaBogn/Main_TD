using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretStats : MonoBehaviour
{
    public float[] stats;
    public static float[] test;
    private string turretName =null;

    public Text turretTxt, levelTxt, dmgTxt, rangeTxt, rateTxt;
    public GameObject StatPanel;
    public GameObject BtnPanel;
    public int level = 1;
    public GameObject turret;

    // Range, FireRate, Damage
    public void GetStats(float[] n)
    {

        turretTxt.text = turretName;
        if (n[3] >= 3)
        {
            turretTxt.text = "Supreme " + turretName;

        }

        StatPanel.gameObject.SetActive(true);
        BtnPanel.gameObject.SetActive(true);

        rangeTxt.text = "Range: " + n[0].ToString();
        rateTxt.text = "Fire Rate: " + n[1].ToString();
        dmgTxt.text = "Damage: " + n[2].ToString();
        levelTxt.text = "Turret Level: " + n[3].ToString();
    }

    public void Setter(GameObject go)
    {
        turret = go;        
        if (go.name.Substring(0, 3) == "Gat")
        {
            turretName = "Gattling Turret";
        }
        if (go.name.Substring(0, 3) == "Las")
        {
            turretName = "Laser Turret";
        }
        if (go.name.Substring(0, 3) == "Mis")
        {
            turretName = "Missile Turret";
        }
        if (go.name.Substring(0, 3) == "Fir")
        {
            turretName = "Fire Turret";
        }
        if (go.name.Substring(0, 3) == "Sni")
        {
            turretName = "Sniper Turret";
        }
        if (go.name.Substring(0, 3) == "Sli")
        {
            turretName = "Slime Turret";
        }
        if (go.name.Substring(0, 3) == "Pow")
        {
            turretName = "Powershot Turret";
        }
        if (go.name.Substring(0, 3) == "Rai")
        {
            turretName = "Railgun Turret";
        }

    }


    public void Upgrade()
    {
        turret.SendMessage("UpgradeTurret", null);

    }

    public void ClearStats()
    {
        StatPanel.gameObject.SetActive(false);
        BtnPanel.gameObject.SetActive(false);

    }

}
