using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SelectTurret : MonoBehaviour
{
    private int count = 0;
    // private int maxCount = 5; // DEPRECATED

    [Header("Unity setup")]
    public GameObject[] turrets; // remembers all turret prefabs
    public Sprite[] sprites; // remembers displaySprite for each prefab
    public Text[] buttons; // collects all buttons to modify content
    public GameObject[] selectedTurrets; // shows selected turrets
    public int[] selectedTurretNumber;
    private bool[] selectedSlotOccupied;

    private bool[] turretHasBeenSelected;

    private void Awake() {
        ChangeButtonNames();
        selectedSlotOccupied = new bool[selectedTurrets.Length];
        for (int i = 0; i < selectedSlotOccupied.Length; i++) {
            selectedSlotOccupied[i] = false;
        }
        turretHasBeenSelected = new bool[turrets.Length];
        for (int i = 0; i < turretHasBeenSelected.Length; i++) {
            turretHasBeenSelected[i] = false;
        }
        selectedTurretNumber = new int[selectedTurrets.Length];
        for (int i = 0; i < selectedTurretNumber.Length; i++) {
            selectedTurretNumber[i] = -1;
        }
    }

    public void StartGame() {
        SceneManager.LoadScene(GameControl.control.targetSceneBuildIndex);
    }
    
    public void ChangeButtonNames() {
        int count = 0;
        foreach(GameObject turret in turrets) {
            if (turret == null)
                break;
            buttons[count].text = turret.name;
            count++;
        }
        count = 0;
        foreach(GameObject x in selectedTurrets) {
            selectedTurrets[count].transform.GetComponentInChildren<Text>().text = "Empty";
            count++;
        }
    }

    public void ClearTurret() {
        string btnClicked = EventSystem.current.currentSelectedGameObject.name;
        EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text = "Empty";
        switch (btnClicked) {
            case "TurretSelected0":
                selectedSlotOccupied[0] = false;
                turretHasBeenSelected[selectedTurretNumber[0]] = false;
                selectedTurretNumber[0] = -1;
                break;
            case "TurretSelected1":
                selectedSlotOccupied[1] = false;
                turretHasBeenSelected[selectedTurretNumber[1]] = false;
                selectedTurretNumber[1] = -1;
                break;
            case "TurretSelected2":
                selectedSlotOccupied[2] = false;
                turretHasBeenSelected[selectedTurretNumber[2]] = false;
                selectedTurretNumber[2] = -1;
                break;
            case "TurretSelected3":
                selectedSlotOccupied[3] = false;
                turretHasBeenSelected[selectedTurretNumber[3]] = false;
                selectedTurretNumber[3] = -1;
                break;
            case "TurretSelected4":
                selectedSlotOccupied[4] = false;
                turretHasBeenSelected[selectedTurretNumber[4]] = false;
                selectedTurretNumber[4] = -1;
                break;
        }
    }

    public bool CheckIfAllSlotsAreOccupied() {
        count = 0;
        for(int i = 0; i < selectedSlotOccupied.Length; i++) {
            if (selectedSlotOccupied[i] == false) {
                count = i;
                return true;
            }
        }
        return false;
    }

    public void ChooseTurret() {
        string btnClicked = EventSystem.current.currentSelectedGameObject.name; // Gets the name of clicked button

        // Checks if player has selected maximum amount of turrets
        if (!CheckIfAllSlotsAreOccupied()) {
            Debug.Log("All slots are occupied");
            return;
        }
        int n = 0;
        GameObject temp = new GameObject();
        switch (btnClicked) {
            case "btn0":
                n = 0;
                if (turretHasBeenSelected[n]) {
                    Debug.Log("Turret has allready been selected");
                    return;
                }
                selectedTurrets[count].transform.GetComponentInChildren<Text>().text = turrets[n].name;
                GameControl.control.prefabs[count] = turrets[n];
                turretHasBeenSelected[n] = true;
                selectedTurretNumber[count] = n;
                break;
            case "btn1":
                n = 1;
                if (turretHasBeenSelected[n]) {
                    Debug.Log("Turret has allready been selected");
                    return;
                }
                selectedTurrets[count].transform.GetComponentInChildren<Text>().text = turrets[n].name;
                GameControl.control.prefabs[count] = turrets[n];
                turretHasBeenSelected[n] = true;
                selectedTurretNumber[count] = n;
                break;
            case "btn2":
                n = 2;
                if (turretHasBeenSelected[n]) {
                    Debug.Log("Turret has allready been selected");
                    return;
                }
                selectedTurrets[count].transform.GetComponentInChildren<Text>().text = turrets[n].name;
                GameControl.control.prefabs[count] = turrets[n];
                turretHasBeenSelected[n] = true;
                selectedTurretNumber[count] = n;
                break;
            case "btn3":
                n = 3;
                if (turretHasBeenSelected[n]) {
                    Debug.Log("Turret has allready been selected");
                    return;
                }
                selectedTurrets[count].transform.GetComponentInChildren<Text>().text = turrets[n].name;
                GameControl.control.prefabs[count] = turrets[n];
                turretHasBeenSelected[n] = true;
                selectedTurretNumber[count] = n;
                break;
            case "btn4":
                n = 4;
                if (turretHasBeenSelected[n]) {
                    Debug.Log("Turret has allready been selected");
                    return;
                }
                selectedTurrets[count].transform.GetComponentInChildren<Text>().text = turrets[n].name;
                GameControl.control.prefabs[count] = turrets[n];
                turretHasBeenSelected[n] = true;
                selectedTurretNumber[count] = n;
                break;
            case "btn5":
                n = 5;
                if (turretHasBeenSelected[n]) {
                    Debug.Log("Turret has allready been selected");
                    return;
                }
                selectedTurrets[count].transform.GetComponentInChildren<Text>().text = turrets[n].name;
                GameControl.control.prefabs[count] = turrets[n];
                turretHasBeenSelected[n] = true;
                selectedTurretNumber[count] = n;
                break;
            case "btn6":
                n = 6;
                if (turretHasBeenSelected[n]) {
                    Debug.Log("Turret has allready been selected");
                    return;
                }
                selectedTurrets[count].transform.GetComponentInChildren<Text>().text = turrets[n].name;
                GameControl.control.prefabs[count] = turrets[n];
                turretHasBeenSelected[n] = true;
                selectedTurretNumber[count] = n;
                break;
            case "btn7":
                n = 7;
                if (turretHasBeenSelected[n]) {
                    Debug.Log("Turret has allready been selected");
                    return;
                }
                selectedTurrets[count].transform.GetComponentInChildren<Text>().text = turrets[n].name;
                GameControl.control.prefabs[count] = turrets[n];
                turretHasBeenSelected[n] = true;
                selectedTurretNumber[count] = n;
                break;
            case "btn8":
                n = 8;
                if (turretHasBeenSelected[n]) {
                    Debug.Log("Turret has allready been selected");
                    return;
                }
                selectedTurrets[count].transform.GetComponentInChildren<Text>().text = turrets[n].name;
                GameControl.control.prefabs[count] = turrets[n];
                turretHasBeenSelected[n] = true;
                selectedTurretNumber[count] = n;
                break;
            case "btn9":
                n = 9;
                if (turretHasBeenSelected[n]) {
                    Debug.Log("Turret has allready been selected");
                    return;
                }
                selectedTurrets[count].transform.GetComponentInChildren<Text>().text = turrets[n].name;
                GameControl.control.prefabs[count] = turrets[n];
                turretHasBeenSelected[n] = true;
                selectedTurretNumber[count] = n;
                break;
            default:
                Debug.Log("Couldnt find turretName");
                break;
        }
        selectedSlotOccupied[count] = true;
    }
}
