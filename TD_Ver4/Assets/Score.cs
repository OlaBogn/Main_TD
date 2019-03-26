using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    
    void Start()
    {
        scoreText.text = "Your score: " + GameControl.control.experience.ToString();
    }
    
}
