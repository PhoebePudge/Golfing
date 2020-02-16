using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour1 : MonoBehaviour
{
    [SerializeField] private Player character;
    
    private Ball b;
    private bool ballPlaced = false;
    void Start(){
        character = new Player(gameObject);
    }
 
    void Update(){
        character.Update();
        if (Input.GetKeyDown(KeyCode.Space)){
            if (!ballPlaced){
                b = new Ball();
                
                ballPlaced = true;
            }
            GameObject.Find("Slider").GetComponent<SliderUI>().isReset = true;
            GameObject.Find("Slider").GetComponent<SliderUI>().isPaused = false;
        }
        if (Input.GetKeyUp(KeyCode.Space)){
            b.MoveToDestination();
            GameObject.Find("Slider").GetComponent<SliderUI>().isPaused = true;
        }
    }
    private void OnDrawGizmos(){
        character.onDrawGizmos();
       
    }
}
