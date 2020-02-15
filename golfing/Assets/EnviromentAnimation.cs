using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentAnimation : MonoBehaviour{
    private void OnCollisionEnter(Collision collision){
       
        Debug.Log(gameObject.name + " hit " + collision.gameObject.name);
        
    }
}
