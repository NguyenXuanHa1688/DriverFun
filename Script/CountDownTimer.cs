using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countdownText;
    public float currentTime = 0f;
    public float startingTime = 10f;
    void Start() {
        currentTime = startingTime;    
    }
    void Update(){
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0.0");
        if(currentTime <= 5){
            countdownText.color = Color.red;
        }
        if(currentTime <= 0){
            countdownText.text = "GAME OVER";
        }
    }
}
