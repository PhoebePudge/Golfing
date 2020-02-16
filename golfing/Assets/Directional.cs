using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Directional : MonoBehaviour{
    public Vector3 Destination;
    private GameObject DestinationGameobject;
    LineRenderer lineRenderer;
    private void Start(){
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        Debug.Log(gameObject);
        DestinationGameobject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        DestinationGameobject.transform.localScale = new Vector3(1,0.1f,1);
        DestinationGameobject.GetComponent<Collider>().isTrigger = true;
        DestinationGameobject.name = "DestinationGameobject";
    }
    void Update(){
        
        DestinationGameobject.gameObject.SetActive(true);
        if (GameObject.Find("Slider").GetComponent<SliderUI>().isPaused == false){
            Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(gameObject.transform.position);
            Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
            float angle = AngleBetween(positionOnScreen, mouseOnScreen);
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, angle, 0f));
             
            lineRenderer = gameObject.GetComponent<LineRenderer>();
            lineRenderer.positionCount = (2);
            lineRenderer.SetPosition(0, gameObject.transform.position);
            lineRenderer.SetPosition(1, gameObject.transform.forward * (GameObject.Find("Slider").GetComponent<Slider>().value / 2) + gameObject.transform.position);
            Destination = gameObject.transform.forward * (GameObject.Find("Slider").GetComponent<Slider>().value / 2) + gameObject.transform.position;
            DestinationGameobject.transform.position = Destination;
        }else{
            lineRenderer.positionCount = 0;
            DestinationGameobject.gameObject.SetActive(false);
        }

    }
    private float AngleBetween(Vector2 vec1, Vector2 vec2){
        Vector2 diference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
    }
    public void StartLerpToDestination(){
        StartCoroutine("LerpToDestination");
        GameObject.Find("Slider").GetComponent<SliderUI>().isPaused = false;
    }
    IEnumerator LerpToDestination(){
        Vector3 a = gameObject.transform.position;
        Vector3 b = gameObject.GetComponent<Directional>().Destination;
        int x = 2;
        for (float f = 0; f <= x; f += Time.deltaTime){
            gameObject.transform.position = Vector3.Lerp(a, b, f / x);
            yield return null;
        }
    }

}
