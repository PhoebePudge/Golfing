using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour{
    [SerializeField] GameObject MenuGM;
    // Start is called before the first frame update
    void Start(){
        MenuGM.SetActive(false);
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            DisplayPauseMenu();
        }
    }
    private void DisplayPauseMenu(){
        GameObject.Find("Slider").GetComponent<SliderUI>().isPaused = true;
        MenuGM.SetActive(true);
    }
}
