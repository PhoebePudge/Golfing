using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderUI : MonoBehaviour{
    private static Slider sl;
    private bool isRevercing = false;
    public GameObject DirectionalPrefab;
    void Start(){
        sl = gameObject.GetComponent<Slider>();
        sl.maxValue = 100;
        sl.value = 0;
    }
    void Update(){
        if (sl.value == sl.maxValue){
            isRevercing = true;
        } else if (sl.value == 0){
            isRevercing = false;
        }
        if (isRevercing){
            sl.value--;
        }else{
            sl.value++;
        }
        CheckForInputPause();
    }
    private void CheckForInputPause(){
        if (Input.GetKeyDown(KeyCode.Space)){
            int tempValue = (int)sl.value;
            Debug.Log(tempValue + " value logged");
            Ball Ball1 = new Ball(DirectionalPrefab);
        }
    }

}

