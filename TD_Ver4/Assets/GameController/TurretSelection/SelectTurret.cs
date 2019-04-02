using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectTurret : MonoBehaviour
{
    private int count = 0;
    private int maxCount = 5;

    [Header("Unity setup")]
    public GameObject[] turrets; // remembers all turret prefabs
    public Sprite[] sprites; // remembers displaySprite for each prefab
    public Text[] buttons; // collects all buttons to modify content
    public GameObject[] selectedTurrets; // shows selected turrets
    
    private void Awake() {
        ChangeButtonNames();
    }

    // TODO: attach prefab to TurretSelected on button clicked

    public void ChangeButtonNames() {
        int count = 0;
        foreach(GameObject turret in turrets) {
            if (turret == null)
                break;
            buttons[count].text = turret.name;
            count++;
        }
    }

    public void UpdateSprite(int n) {
        selectedTurrets[count].GetComponent<SpriteRenderer>().sprite = sprites[n];
        
    }

    public void ChooseTurret() {
        string btnClicked = EventSystem.current.currentSelectedGameObject.name; // Gets the name of clicked button
        Debug.Log("Count = " + count + " Button pressed: " + btnClicked);
        
        // Checks if player has selected maximum amount of turrets
        if (count >= maxCount) {
            Debug.Log("Tried to exceed maxCount variable.");
            return;
        }

        switch (btnClicked) {
            case "btn0":
                selectedTurrets[count] = turrets[0];
                UpdateSprite(0);
                break;
            case "btn1":
                selectedTurrets[count] = turrets[1];
                UpdateSprite(1);
                break;
            case "btn2":
                selectedTurrets[count] = turrets[2];
                UpdateSprite(2);
                break;
            case "btn3":
                selectedTurrets[count] = turrets[3];
                UpdateSprite(3);
                break;
            case "btn4":
                selectedTurrets[count] = turrets[4];
                UpdateSprite(4);
                break;
            case "btn5":
                selectedTurrets[count] = turrets[5];
                UpdateSprite(5);
                break;
            case "btn6":
                selectedTurrets[count] = turrets[6];
                UpdateSprite(6);
                break;
            case "btn7":
                selectedTurrets[count] = turrets[7];
                UpdateSprite(7);
                break;
            case "btn8":
                selectedTurrets[count] = turrets[8];
                UpdateSprite(8);
                break;
            case "btn9":
                selectedTurrets[count] = turrets[9];
                UpdateSprite(9);
                break;
            default:
                Debug.Log("Couldnt find turretName");
                break;
        }
        count++;
    }
}
