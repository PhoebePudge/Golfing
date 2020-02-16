using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball{
    public GameObject gm;
    private int ForceMultiplyer = 0;
    public Ball(){
        gm = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        gm.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        gm.name = "Golf Ball";
        gm.transform.position = playerPosition();
        gm.transform.eulerAngles = playerRotation();
        gm.AddComponent<Rigidbody>().AddForce(Vector3.forward * ForceMultiplyer);
        gm.layer = 10;
        Directional d1 = gm.AddComponent<Directional>();
    }
    private Vector3 playerPosition() {return GameObject.Find("Player").transform.position;}
    private Vector3 playerRotation() { return GameObject.Find("Player").transform.rotation.eulerAngles; }
    public void MoveToDestination(){
        gm.GetComponent<Directional>().StartLerpToDestination();
    }
    

}
