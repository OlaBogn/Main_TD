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
        foreach (GameObject turret in turrets) {
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

    public bool CheckIfAllSlotsAreOccupied() {
        count = 0;
        for (int i = 0; i < selectedSlotOccupied.Length; i++) {
            if (selectedSlotOccupied[i] == false) {
                count = i;
                return true;
            }
        }
        return false;
    }



    public void ClearTurret() {
        string btnClicked = EventSystem.current.currentSelectedGameObject.name;
        EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text = "Empty";

        int n = 0;

        switch (btnClicked) {
            case "TurretSelected0":
                n = 0;
                selectedSlotOccupied[n] = false;
                if (turretHasBeenSelected[n]) {
                    turretHasBeenSelected[selectedTurretNumber[n]] = false;
                    selectedTurretNumber[n] = -1;
                }
                break;
            case "TurretSelected1":
                n = 1;
                selectedSlotOccupied[n] = false;
                if (turretHasBeenSelected[n]) {
                    turretHasBeenSelected[selectedTurretNumber[n]] = false;
                    selectedTurretNumber[n] = -1;
                }
                break;
            case "TurretSelected2":
                n = 2;
                selectedSlotOccupied[n] = false;
                if (turretHasBeenSelected[n]) {
                    turretHasBeenSelected[selectedTurretNumber[n]] = false;
                    selectedTurretNumber[n] = -1;
                }
                break;
            case "TurretSelected3":
                n = 3;
                selectedSlotOccupied[n] = false;
                if (turretHasBeenSelected[n]) {
                    turretHasBeenSelected[selectedTurretNumber[n]] = false;
                    selectedTurretNumber[n] = -1;
                }
                break;
            case "TurretSelected4":
                n = 4;
                selectedSlotOccupied[n] = false;
                if (turretHasBeenSelected[n]) {
                    turretHasBeenSelected[selectedTurretNumber[n]] = false;
                    selectedTurretNumber[n] = -1;
                }
                break;
        }
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
