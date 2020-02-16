using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;

    private Vector3 middlePoint;
    private float distanceFromMiddlePoint;
    private float distanceBetweenPlayers;
    private float aspectRatio;
    // Start is called before the first frame update
    void Start()
    {
        aspectRatio = Screen.width / Screen.height;
        Camera.main.orthographic = true;
        
    }

    void Update()
    {
        pos1 = GameObject.Find("Player").transform;
        if (GameObject.Find("DestinationGameobject") != null){
            pos2 = GameObject.Find("DestinationGameobject").transform;
        }
        

        // Find the middle point between players.
        middlePoint = pos1.position + 0.5f * (pos2.position - pos1.position);

        // Position the camera in the center.
        Vector3 newCameraPos = gameObject.transform.position;
        newCameraPos.x = middlePoint.x;
        gameObject.transform.position = newCameraPos;

        // Calculate the new FOV.
        distanceBetweenPlayers = (pos2.position - pos1.position).magnitude;
        distanceFromMiddlePoint = (Camera.main.transform.position - middlePoint).magnitude;
        Camera.main.orthographicSize = 0.5f * Mathf.Rad2Deg * Mathf.Atan((0.5f * distanceBetweenPlayers) / (distanceFromMiddlePoint * aspectRatio));
        if (Camera.main.orthographicSize < 15)
        {
            Camera.main.orthographicSize = 15;
        }
    }
}
