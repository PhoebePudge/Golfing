using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour{
    float timer = 0;
    public bool TimerStopped = false;
    void Start(){
        
    }

    void Update(){
        if (!TimerStopped){
            timer += Time.deltaTime;
        }
        gameObject.GetComponent<TextMeshProUGUI>().text = "Timer: " + (int)timer;
    }

}
