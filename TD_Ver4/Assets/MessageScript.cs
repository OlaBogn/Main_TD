using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageScript : MonoBehaviour
{
    private string text = "";
    public GameObject MessagePanel;
    public Text message;

    public void Caller(string input)
    {
        
        text = input;
        StartCoroutine(ShowMessage());
    }

    IEnumerator ShowMessage()
    {
        message.text = text;
        MessagePanel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        MessagePanel.SetActive(false);
        
    }

    
}
