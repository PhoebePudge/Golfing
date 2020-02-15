using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Directional : MonoBehaviour{
    public GameObject directionalPrefab;
    private void Start()
    {
        directionalPrefab.gameObject.AddComponent<LineRenderer>();
    }
    void Update(){
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(directionalPrefab.transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle =  AngleBetween(positionOnScreen, mouseOnScreen);
        Debug.Log("Angle");
        directionalPrefab.transform.rotation = Quaternion.Euler(new Vector3(0f, angle, 0f));

        LineRenderer lineRenderer = directionalPrefab.GetComponent<LineRenderer>();
        lineRenderer.positionCount = (2);
        lineRenderer.SetPosition(0, directionalPrefab.transform.position);
        lineRenderer.SetPosition(1, directionalPrefab.transform.forward * 50 + directionalPrefab.transform.position);

    }
    private float AngleBetween(Vector2 vec1, Vector2 vec2){
        Vector2 diference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
    }

    private void OnDrawGizmos()
    {
        
    }
}
