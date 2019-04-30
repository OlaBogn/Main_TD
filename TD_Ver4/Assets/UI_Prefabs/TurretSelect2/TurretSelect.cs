using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TurretSelect : MonoBehaviour
{
    [Header("Unity setup")]
    public Sprite emptyPlaceholder;
    public GameObject[] turrets = new GameObject[10];

    [Header("Script defined refferences")]
    public GameObject[] turretButtons;
    public GameObject[] turretSelectedButtons;
    public GameObject[] infoPanels;

    public Sprite[] baseSprite;
    public Sprite[] topSprite;

    public bool[] selectedSlotsOccupied;
    public GameObject emptyPrefab; // used to erase turretprefab in gamecontroller

    // TurretPrices TODO: update before release
    private int gattling = 105;
    private int laser = 110;
    private int missile = 150;
    private int fire = 90;
    private int powershot = 120;
    private int railgun = 135;
    private int slime = 105;
    private int sniper = 140;
    private int nukethrower = 300;
    private int artilleri = 130;

    void Start() {
        UpdateTurretButtons();
        emptyPrefab = new GameObject();
        UpdateInfoPanels();
    }

    void UpdateInfoPanels() {
        int count = 0;
        
        foreach(GameObject panel in infoPanels) {
            float damage, fireRate, range, splashRadius;

            switch (count) {
                case 0:
                    damage = turrets[count].GetComponent<GattlingTurretScript>().bulletPrefab.GetComponent<Bullet>().bulletDamage;
                    fireRate = turrets[count].GetComponent<GattlingTurretScript>().fireRate;
                    range = turrets[count].GetComponent<GattlingTurretScript>().range;
                    splashRadius = turrets[count].GetComponent<GattlingTurretScript>().bulletPrefab.GetComponent<Bullet>().splashRadius;


                    panel.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Damage: " + damage.ToString();
                    panel.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Firerate: " + fireRate.ToString();
                    panel.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Range: " + range.ToString();
                    panel.transform.GetChild(3).gameObject.GetComponent<Text>().text = "Price: " + gattling.ToString();
                    if (turrets[count].GetComponent<GattlingTurretScript>().bulletPrefab.GetComponent<Bullet>().hasSplashDamage) {
                        panel.transform.GetChild(4).gameObject.GetComponent<Text>().text = "Splash: " + splashRadius.ToString();
                    } else {
                        panel.transform.GetChild(4).gameObject.GetComponent<Text>().text = "Splash: " + "none";
                    }
                    break;
                case 1:
                    damage = turrets[count].GetComponent<LaserTurretScript>().bulletPrefab.GetComponent<Bullet>().bulletDamage;
                    fireRate = turrets[count].GetComponent<LaserTurretScript>().fireRate;
                    range = turrets[count].GetComponent<LaserTurretScript>().range;
                    splashRadius = turrets[count].GetComponent<LaserTurretScript>().bulletPrefab.GetComponent<Bullet>().splashRadius;

                    panel.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Damage: " + damage.ToString();
                    panel.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Firerate: " + fireRate.ToString();
                    panel.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Range: " + range.ToString();
                    panel.transform.GetChild(3).gameObject.GetComponent<Text>().text = "Price: " + laser.ToString();
                    if (turrets[count].GetComponent<LaserTurretScript>().bulletPrefab.GetComponent<Bullet>().hasSplashDamage) {
                        panel.transform.GetChild(4).gameObject.GetComponent<Text>().text = "Splash: " + splashRadius.ToString();
                    } else {
                        panel.transform.GetChild(4).gameObject.GetComponent<Text>().text = "Splash: " + "none";
                    }
                    break;
                case 2:
                    damage = turrets[count].GetComponent<FireTurretScript>().bulletPrefab.GetComponent<Bullet>().bulletDamage;
                    fireRate = turrets[count].GetComponent<FireTurretScript>().fireRate;
                    range = turrets[count].GetComponent<FireTurretScript>().range;
                    splashRadius = turrets[count].GetComponent<FireTurretScript>().bulletPrefab.GetComponent<Bullet>().splashRadius;

                    panel.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Damage: " + damage.ToString();
                    panel.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Firerate: " + fireRate.ToString();
                    panel.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Range: " + range.ToString();
                    panel.transform.GetChild(3).gameObject.GetComponent<Text>().text = "Price: " + fire.ToString();
                    if (turrets[count].GetComponent<FireTurretScript>().bulletPrefab.GetComponent<Bullet>().hasSplashDamage) {
                        panel.transform.GetChild(4).gameObject.GetComponent<Text>().text = "Splash: " + splashRadius.ToString();
                    } else {
                        panel.transform.GetChild(4).gameObject.GetComponent<Text>().text = "Splash: " + "none";
                    }
                    break;
                case 3:
                    damage = turrets[count].GetComponent<MissileTurret>().bulletPrefab.GetComponent<Bullet>().bulletDamage;
                    fireRate = turrets[count].GetComponent<MissileTurret>().fireRate;
                    range = turrets[count].GetComponent<MissileTurret>().range;
                    splashRadius = turrets[count].GetComponent<MissileTurret>().bulletPrefab.GetComponent<Bullet>().splashRadius;

                    panel.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Damage: " + damage.ToString();
                    panel.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Firerate: " + fireRate.ToString();
                    panel.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Range: " + range.ToString();
                    panel.transform.GetChild(3).gameObject.GetComponent<Text>().text = "Price: " + missile.ToString();
                    if (turrets[count].GetComponent<MissileTurret>().bulletPrefab.GetComponent<Bullet>().hasSplashDamage) {
                        panel.transform.GetChild(4).gameObject.GetComponent<Text>().text = "Splash: " + splashRadius.ToString();
                    } else {
                        panel.transform.GetChild(4).gameObject.GetComponent<Text>().text = "Splash: " + "none";
                    }
                    break;
                case 4:
                    damage = turrets[count].GetComponent<SlimeTurretScript>().bulletPrefab.GetComponent<Bullet>().bulletDamage;
                    fireRate = turrets[count].GetComponent<SlimeTurretScript>().fireRate;
                    range = turrets[count].GetComponent<SlimeTurretScript>().range;
                    splashRadius = turrets[count].GetComponent<SlimeTurretScript>().bulletPrefab.GetComponent<Bullet>().splashRadius;

                    panel.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Damage: " + damage.ToString();
                    panel.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Firerate: " + fireRate.ToString();
                    panel.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Range: " + range.ToString();
                    panel.transform.GetChild(3).gameObject.GetComponent<Text>().text = "Price: " + slime.ToString();
                    if (turrets[count].GetComponent<SlimeTurretScript>().bulletPrefab.GetComponent<Bullet>().hasSplashDamage) {
                        panel.transform.GetChild(4).gameObject.GetComponent<Text>().text = "Splash: " + splashRadius.ToString();
                    } else {
                        panel.transform.GetChild(4).gameObject.GetComponent<Text>().text = "Splash: " + "none";
                    }
                    break;
                case 5:
                    damage = turrets[count].GetComponent<SniperTurretScript>().bulletPrefab.GetComponent<Bullet>().bulletDamage;
                    fireRate = turrets[count].GetComponent<SniperTurretScript>().fireRate;
                    range = turrets[count].GetComponent<SniperTurretScript>().range;
                    splashRadius = turrets[count].GetComponent<SniperTurretScript>().bulletPrefab.GetComponent<Bullet>().splashRadius;

                    panel.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Damage: " + damage.ToString();
                    panel.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Firerate: " + fireRate.ToString();
                    panel.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Range: " + range.ToString();
                    panel.transform.GetChild(3).gameObject.GetComponent<Text>().text = "Price: " + sniper.ToString();
                    if (turrets[count].GetComponent<SniperTurretScript>().bulletPrefab.GetComponent<Bullet>().hasSplashDamage) {
                        panel.transform.GetChild(4).gameObject.GetComponent<Text>().text = "Splash: " + splashRadius.ToString();
                    } else {
                        panel.transform.GetChild(4).gameObject.GetComponent<Text>().text = "Splash: " + "none";
                    }
                    break;
                case 6:
                    damage = turrets[count].GetComponent<PowershotTurretScript>().bulletPrefab.GetComponent<Bullet>().bulletDamage;
                    fireRate = turrets[count].GetComponent<PowershotTurretScript>().fireRate;
                    range = turrets[count].GetComponent<PowershotTurretScript>().range;
                    splashRadius = turrets[count].GetComponent<PowershotTurretScript>().bulletPrefab.GetComponent<Bullet>().splashRadius;

                    panel.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Damage: " + damage.ToString();
                    panel.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Firerate: " + fireRate.ToString();
                    panel.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Range: " + range.ToString();
                    panel.transform.GetChild(3).gameObject.GetComponent<Text>().text = "Price: " + powershot.ToString();
                    if (turrets[count].GetComponent<PowershotTurretScript>().bulletPrefab.GetComponent<Bullet>().hasSplashDamage) {
                        panel.transform.GetChild(4).gameObject.GetComponent<Text>().text = "Splash: " + splashRadius.ToString();
                    } else {
                        panel.transform.GetChild(4).gameObject.GetComponent<Text>().text = "Splash: " + "none";
                    }
                    break;
                case 7:
                    damage = turrets[count].GetComponent<RailgunTurretScript>().bulletPrefab.GetComponent<Bullet>().bulletDamage;
                    fireRate = turrets[count].GetComponent<RailgunTurretScript>().fireRate;
                    range = turrets[count].GetComponent<RailgunTurretScript>().range;
                    splashRadius = turrets[count].GetComponent<RailgunTurretScript>().bulletPrefab.GetComponent<Bullet>().splashRadius;

                    panel.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Damage: " + damage.ToString();
                    panel.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Firerate: " + fireRate.ToString();
                    panel.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Range: " + range.ToString();
                    panel.transform.GetChild(3).gameObject.GetComponent<Text>().text = "Price: " + railgun.ToString();
                    if (turrets[count].GetComponent<RailgunTurretScript>().bulletPrefab.GetComponent<Bullet>().hasSplashDamage) {
                        panel.transform.GetChild(4).gameObject.GetComponent<Text>().text = "Splash: " + splashRadius.ToString();
                    } else {
                        panel.transform.GetChild(4).gameObject.GetComponent<Text>().text = "Splash: " + "none";
                    }
                    break;
                case 8:
                    damage = turrets[count].GetComponent<ArtilleryTurretScript>().bulletPrefab.GetComponent<Bullet>().bulletDamage;
                    fireRate = turrets[count].GetComponent<ArtilleryTurretScript>().fireRate;
                    range = turrets[count].GetComponent<ArtilleryTurretScript>().range;
                    splashRadius = turrets[count].GetComponent<ArtilleryTurretScript>().bulletPrefab.GetComponent<Bullet>().splashRadius;

                    panel.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Damage: " + damage.ToString();
                    panel.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Firerate: " + fireRate.ToString();
                    panel.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Range: " + range.ToString();
                    panel.transform.GetChild(3).gameObject.GetComponent<Text>().text = "Price: " + artilleri.ToString();
                    if (turrets[count].GetComponent<ArtilleryTurretScript>().bulletPrefab.GetComponent<Bullet>().hasSplashDamage) {
                        panel.transform.GetChild(4).gameObject.GetComponent<Text>().text = "Splash: " + splashRadius.ToString();
                    } else {
                        panel.transform.GetChild(4).gameObject.GetComponent<Text>().text = "Splash: " + "none";
                    }
                    break;
                case 9:
                    damage = turrets[count].GetComponent<NukethrowerScript>().bulletPrefab.GetComponent<Bullet>().bulletDamage;
                    fireRate = turrets[count].GetComponent<NukethrowerScript>().fireRate;
                    range = turrets[count].GetComponent<NukethrowerScript>().range;
                    splashRadius = turrets[count].GetComponent<NukethrowerScript>().bulletPrefab.GetComponent<Bullet>().splashRadius;

                    panel.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Damage: " + damage.ToString();
                    panel.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Firerate: " + fireRate.ToString();
                    panel.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Range: " + range.ToString();
                    panel.transform.GetChild(3).gameObject.GetComponent<Text>().text = "Price: " + nukethrower.ToString();
                    if (turrets[count].GetComponent<NukethrowerScript>().bulletPrefab.GetComponent<Bullet>().hasSplashDamage) {
                        panel.transform.GetChild(4).gameObject.GetComponent<Text>().text = "Splash: " + splashRadius.ToString();
                    } else {
                        panel.transform.GetChild(4).gameObject.GetComponent<Text>().text = "Splash: " + "none";
                    }
                    break;
            }

            count++;
        }
    }
    
    void UpdateTurretButtons() {
        
        // child(0) = TurretButtons, child(1) = TurretsSelected, child(2) = InfoPanels
        turretButtons = new GameObject[gameObject.transform.GetChild(0).transform.childCount]; // children of TurretButtons
        infoPanels = new GameObject[gameObject.transform.GetChild(2).transform.childCount]; // children of InfoPanels
        turretSelectedButtons = new GameObject[gameObject.transform.GetChild(1).transform.childCount]; // children of TurretsSelected

        baseSprite = new Sprite[turrets.Length];
        topSprite = new Sprite[turrets.Length];

        selectedSlotsOccupied = new bool[turretSelectedButtons.Length];

        // Setts up turretButtons & infoPanel array references
        for (int i = 0; i < turretButtons.Length; i++) {
            turretButtons[i] = gameObject.transform.GetChild(0).transform.GetChild(i).gameObject;
            infoPanels[i] = gameObject.transform.GetChild(2).transform.GetChild(i).gameObject;

            // Setts up baseSprite array
            baseSprite[i] = turrets[i].GetComponent<SpriteRenderer>().sprite;

            // Setts up topSprite array
            topSprite[i] = turrets[i].transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;

            // writes text- and image- elements onto turretButtons
            turretButtons[i].transform.GetChild(0).GetComponent<Text>().text = turrets[i].name;
            turretButtons[i].transform.GetChild(2).GetComponent<Image>().sprite = topSprite[i];
            turretButtons[i].transform.GetChild(1).GetComponent<Image>().sprite = baseSprite[i];
        }

        // Setts up turretSelectedButtons array refferences
        for (int i = 0; i < turretSelectedButtons.Length; i++) {
            turretSelectedButtons[i] = gameObject.transform.GetChild(1).transform.GetChild(i).gameObject;
        }

        // Setts up turretSelectedButtons
        for (int i = 0; i < turretSelectedButtons.Length; i++) {
            for (int n = 0; n < turrets.Length; n++) {
                if (GameControl.control.prefabs[i].name == turrets[n].name) {
                    turretSelectedButtons[i].transform.GetChild(0).GetComponent<Text>().text = turrets[n].name;
                    turretSelectedButtons[i].transform.GetChild(1).GetComponent<Image>().sprite = baseSprite[n];
                    turretSelectedButtons[i].transform.GetChild(2).GetComponent<Image>().sprite = topSprite[n];
                }
            }
        }

        // Setts up selectedSlotsOccupied array
        for (int i = 0; i < selectedSlotsOccupied.Length; i++) {
            selectedSlotsOccupied[i] = true;
        }
    }

    public void SelectTurretClicked() {
        
        string turretName = EventSystem.current.currentSelectedGameObject.gameObject.transform.GetChild(0).GetComponent<Text>().text;
        int counter = 0;

        for (int i = 0; i < selectedSlotsOccupied.Length; i++) {
            if (selectedSlotsOccupied[i]) {
                counter++;
            } else {
                break;
            }
        }

        if (counter >= selectedSlotsOccupied.Length) {
            Debug.Log("All slots occupied: " + selectedSlotsOccupied.Length);
            return;
        }

        for (int i = 0; i < GameControl.control.prefabs.Length; i++) {
            if (turretName == GameControl.control.prefabs[i].name) {
                Debug.Log("Turret is allready selected");
                return;
            }
        }

        selectedSlotsOccupied[counter] = true;

        //TODO: set each turret into count position
        if (turretName == turrets[0].name) {
            GameControl.control.prefabs[counter] = turrets[0];
            RefreshSelectedTurrets();
        } else if (turretName == turrets[1].name) {
            GameControl.control.prefabs[counter] = turrets[1];
            RefreshSelectedTurrets();
        } else if (turretName == turrets[2].name) {
            GameControl.control.prefabs[counter] = turrets[2];
            RefreshSelectedTurrets();
        } else if (turretName == turrets[3].name) {
            GameControl.control.prefabs[counter] = turrets[3];
            RefreshSelectedTurrets();
        } else if (turretName == turrets[4].name) {
            GameControl.control.prefabs[counter] = turrets[4];
            RefreshSelectedTurrets();
        } else if (turretName == turrets[5].name) {
            GameControl.control.prefabs[counter] = turrets[5];
            RefreshSelectedTurrets();
        } else if (turretName == turrets[6].name) {
            GameControl.control.prefabs[counter] = turrets[6];
            RefreshSelectedTurrets();
        } else if (turretName == turrets[7].name) {
            GameControl.control.prefabs[counter] = turrets[7];
            RefreshSelectedTurrets();
        } else if (turretName == turrets[8].name) {
            GameControl.control.prefabs[counter] = turrets[8];
            RefreshSelectedTurrets();
        } else if (turretName == turrets[9].name) {
            GameControl.control.prefabs[counter] = turrets[9];
            RefreshSelectedTurrets();
        }
    }

    void RefreshSelectedTurrets() {
        int counter = 0;
        for (int i = 0; i < turretSelectedButtons.Length; i++) {
            for (int n = 0; n < turrets.Length; n++) {
                if (GameControl.control.prefabs[i].name.Substring(0,3) == "New") {
                    break;
                }
                if (GameControl.control.prefabs[i].name == turrets[n].name) {
                    turretSelectedButtons[i].transform.GetChild(0).GetComponent<Text>().text = turrets[n].name;
                    turretSelectedButtons[i].transform.GetChild(1).GetComponent<Image>().sprite = baseSprite[n];
                    turretSelectedButtons[i].transform.GetChild(2).GetComponent<Image>().sprite = topSprite[n];
                }
            }
        }
        counter++;
    }

    public void ClearSelectedTurret() {
        string selectedTurretName = EventSystem.current.currentSelectedGameObject.gameObject.transform.GetChild(0).GetComponent<Text>().text;
        if (selectedTurretName == "Empty") {
            Debug.Log("Slot is empty");
            return;
        }

        GameObject temp = null;

        for (int i = 0; i < turretSelectedButtons.Length; i++) {
            if (turretSelectedButtons[i].transform.GetChild(0).GetComponent<Text>().text == selectedTurretName) {
                temp = turretSelectedButtons[i];
                selectedSlotsOccupied[i] = false;
                GameControl.control.prefabs[i] = emptyPrefab;
                break;
            }
        }
        
        temp.transform.GetChild(0).GetComponent<Text>().text = "Empty";
        temp.transform.GetChild(1).GetComponent<Image>().sprite = emptyPlaceholder;
        temp.transform.GetChild(2).GetComponent<Image>().sprite = emptyPlaceholder;
    }
}
