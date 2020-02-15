using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball{
    private GameObject gm;
    private int ForceMultiplyer = 0;
    private bool isPlaced = false;


    public Ball(GameObject prefab){
        if (isPlaced == false)
        {
            gm = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            gm.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            gm.name = "Golf Ball";
            gm.transform.position = playerPosition();
            gm.transform.eulerAngles = playerRotation();
            gm.AddComponent<Rigidbody>().AddForce(Vector3.forward * ForceMultiplyer);
            gm.layer = 10;

            Directional d1 = gm.AddComponent<Directional>();
            d1.directionalPrefab = (GameObject)GameObject.Instantiate(prefab, gm.transform.position - new Vector3(0, 1, 0), Quaternion.identity);
            isPlaced = true;
        }
        Debug.Log("Player has already placed a ball");
    }
    private Vector3 playerPosition() {return GameObject.Find("Player").transform.position;}
    private Vector3 playerRotation() { return GameObject.Find("Player").transform.rotation.eulerAngles; }
}
