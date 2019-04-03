using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateButtonNames : MonoBehaviour
{

    public GameObject[] btnsSelected;

    private void Start() {
        for (int i = 0; i < btnsSelected.Length; i++) {
            GameObject go = btnsSelected[i].transform.GetChild(0).gameObject;
            go.GetComponent<Text>().text = GameControl.control.prefabs[i].name;
        }
    }
}
