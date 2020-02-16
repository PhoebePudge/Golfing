using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderUI : MonoBehaviour{
    public bool isPaused = true;
    public bool isReset = false;

    private static Slider sl;
    private bool isRevercing = false;
    void Start(){
        sl = gameObject.GetComponent<Slider>();
        sl.maxValue = 100;
        sl.value = 0;
    }
    void Update(){
        Debug.Log(isPaused);
        if (!isPaused){
            if (sl.value == sl.maxValue){
                isRevercing = true;
            }else if (sl.value == 0){
                isRevercing = false;
            }
            if (isRevercing){
                sl.value--;
            }else{
                sl.value++;
            }
        }
        if (isReset)
        {
            sl.value = 0;
            isReset = false;
        }
    }
    public void PauseSlider()
    {
        isPaused = true;
    }
    
}

