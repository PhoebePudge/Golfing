using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    [SerializeField] private GameObject gm; //player gameobject from visual transformation
    private Rigidbody rb; //rigidbody of player gameobject
    [SerializeField] private float speedMultiplier = 5; //multipier for speed
    [SerializeField] private GameObject cm; //camera gameobject
    
    // Start is called before the first frame update
    public void Start(){
        #region rb
        if (gm.GetComponent<Rigidbody>() == null){
            gm.AddComponent<Rigidbody>();
        }
        rb = gm.GetComponent<Rigidbody>();
        #endregion
        gm.name = "Player";
    }

    // Update is called once per frame
    public void Update(){
        if (!CheckForException()){
            KeyboardMovement();
        }
    }
    private void KeyboardMovement(){
        //basic movement using key inputs
        //todo: change to andriod input : used for quick prototyping
        if (Input.GetKey(KeyCode.W)){
            MoveUp();
        }
        else if (Input.GetKey(KeyCode.S)){
            MoveDown();
        }
        else if (Input.GetKey(KeyCode.D)){
            MoveRight();
        }
        else if (Input.GetKey(KeyCode.A)){
            MoveLeft();
        }
    }
    private void MoveUp(){rb.MovePosition(gm.transform.position + (gm.transform.forward * Time.fixedDeltaTime) * speedMultiplier);}
    private void MoveLeft(){rb.MovePosition(gm.transform.position + (-gm.transform.right * Time.fixedDeltaTime) * speedMultiplier);}
    private void MoveRight(){rb.MovePosition(gm.transform.position + (gm.transform.right * Time.fixedDeltaTime) * speedMultiplier);}
    private void MoveDown(){rb.MovePosition(gm.transform.position + (-gm.transform.forward * Time.fixedDeltaTime) * speedMultiplier);}
    private bool CheckForException(){
        //check for any null values or exceptions before execution
        if (gm == null){
            Debug.LogError("gm within player script is null.");
            return true;
        }else if (rb == null){
            Debug.LogError("rb within player script is null.");
            return true;
        }else if (cm == null){
            Debug.LogError("cm within player script is null.");
            return true;
        }else{
            return false;
        }
    }
    public void onDrawGizmos(){
        //called within the onDrawGizmos monobehaviour function
        Gizmos.color = Color.blue;
        Camera cam = cm.GetComponent<Camera>();
        Vector3 r1 = RaycastScreenPoint(new Vector2(cam.pixelWidth, 0));
        Vector3 r2 = RaycastScreenPoint(new Vector2(cam.pixelWidth, cam.pixelHeight));
        Vector3 l1 = RaycastScreenPoint(new Vector2(0, 0));
        Vector3 l2 = RaycastScreenPoint(new Vector2(0, cam.pixelHeight));
        Debug.Log("r1: " + r1 + " r2: " + r2 + " l1: " + l1 + " l2: " + l2);
        Gizmos.DrawLine(r1, r2);
        Gizmos.DrawLine(l1, l1);
        Gizmos.DrawLine(r1, l1);
        Gizmos.DrawLine(r2, l2);
    }
    private Vector3 RaycastScreenPoint(Vector3 v3){
        var ray = Camera.main.ScreenPointToRay(v3);
        RaycastHit hitPoint;
        if (Physics.Raycast(ray, out hitPoint, 100.0f)){
            return hitPoint.point;
        }
        return new Vector3(0,0,0);
    }

}
