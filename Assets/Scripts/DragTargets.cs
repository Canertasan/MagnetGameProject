using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Linq;

public class DragTargets : MonoBehaviour
{
    // mouse object for cursor.
    public GameObject gObj = null, mouse, button;
    public Plane objPlane;
    public Vector3 m0, distance;
    Rigidbody rb;
    public bool afterMoveFinished = false;


    Ray GenerateTouchRay(Vector3 touchPos)
    {
        Vector3 touchPosFar = new Vector3(touchPos.x, touchPos.y, Camera.main.farClipPlane);
        Vector3 touchPosNear = new Vector3(touchPos.x, touchPos.y, Camera.main.nearClipPlane);
        Vector3 touchPosF = Camera.main.ScreenToWorldPoint(touchPosFar);
        Vector3 touchPosN = Camera.main.ScreenToWorldPoint(touchPosNear);
        Ray mr = new Ray(touchPosN, touchPosF - touchPosN);
        return mr;
    }

    private void Start()
    {   
        mouse = GameObject.Find("MouseObject");
        distance = new Vector3();
        button = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("restartButton")); // to find not active gameobject.
    }

    private void MouseReset()
    {
        Vector3 temp = new Vector3(0, 0, 0);
        mouse.transform.position = temp; // put mouse inside of the ground, user cannot see and cannot click
        mouse.GetComponent<Renderer>().enabled = false;  // for any case hide the object.
    }


    void FixedUpdate()
    {
        try
        {
            if (Input.touchCount > 0 && button.activeSelf != true) // when level is finished then player cannot move magnet.
            {
                
                if (Input.GetTouch(0).phase == TouchPhase.Began)  // Began phase
                {
                    Ray touchRay = GenerateTouchRay(Input.GetTouch(0).position); // create Ray
                    RaycastHit hit;

                    if (Physics.Raycast(touchRay.origin, touchRay.direction, out hit))
                    {
                        gObj = hit.transform.gameObject; // take the object we clicked.
                        objPlane = new Plane(Camera.main.transform.forward * -1, gObj.transform.position);

                        Ray mRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);  // clicking position.
                        float rayDistance;
                        objPlane.Raycast(mRay, out rayDistance);

                        if (gObj.tag.Equals("Draggable")) // If object is draggable
                        {
                            // then show cursor object
                            mouse.GetComponent<Renderer>().enabled = true;
                        }
                    }
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Moved && gObj)// if dragging the screen
                {

                    Ray mRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    float rayDistance;
                    if (objPlane.Raycast(mRay, out rayDistance) && gObj.tag.Equals("Draggable"))
                    {
                        Vector3 vec = new Vector3(0, 1, 0);
                        mouse.transform.position = mRay.GetPoint(rayDistance) + vec; // mouse position is same position our touching.

                        distance = (mRay.GetPoint(rayDistance) - gObj.transform.position) ; // distance between those.
                        distance.y = 0;
                        rb = gObj.GetComponent<Rigidbody>();
                        if (rb.velocity.magnitude < 3) // top speed is this.
                        {
                            rb.AddForce(rb.mass*distance/Time.fixedDeltaTime); // calculating force 
                        }
                    }
                    afterMoveFinished = true;
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended && gObj) // if dropping the screen
                { // finish the process...
                    afterMoveFinished = false;
                    MouseReset();
                    gObj = null; // make Obj null again 
                }
            }
            else if(afterMoveFinished) // this is for when i get of my finger from screen, It does not finish the process of TouchPhase.Ended
            {  // Because touchCount simply 0, This if statement is forcing to finish that process.
                afterMoveFinished = false;
                MouseReset();
                gObj = null; // make Obj null again 
            }
        }
        catch(Exception ex)
        { // Sometimes when i get my hand of too quickly it enter if because touchCount was bigger then 0 But
            // When it tried to check if statements then It is simply giving an error. This code catch them and finish process if it is the case.
            Debug.LogError(ex);
            afterMoveFinished = false;
            MouseReset();
            gObj = null; // make Obj null again 
        }
       
    }

}