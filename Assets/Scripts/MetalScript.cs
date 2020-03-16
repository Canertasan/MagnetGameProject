using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MetalScript : MonoBehaviour
{
    //private float cycleInterval = 0.01f; // 100 times in a sec
    GameObject magnetObj;
    public float F;
    public float I = 3;
    public float A;
    public float B;
    public float uo = 4 * Mathf.PI * Mathf.Pow(10, -7);
    public float forceConstant = 10.0f;
    public Color c;
    
    GameObject[] metalObjects;

    private void Start()
    {
        metalObjects = GameObject.FindGameObjectsWithTag("MetalObject"); // all metal objects
        c = metalObjects[0].GetComponent<Renderer>().material.GetColor("_Color");  // get metal object base color.
        magnetObj = GameObject.FindGameObjectWithTag("Draggable");  // assume there is only one magnet.
        Vector3 originalScale = magnetObj.transform.localScale;
        A = originalScale.x * originalScale.x * 6;
    }

    private void FixedUpdate()
    {
        foreach (GameObject metalObject in metalObjects)
        {
            float distance = Mathf.Sqrt(Mathf.Pow((magnetObj.transform.position.x - metalObject.transform.position.x), 2) + Mathf.Pow((magnetObj.transform.position.z - metalObject.transform.position.z), 2));
            if (distance <= 2.5) // do not interact if distance is bigger then 2.5
            {
                metalObject.GetComponent<Renderer>().material.color = Color.green;  // if metal is pulling then make metal is green
                B = (uo * I) / (2 * Mathf.PI * distance); // micro tesla  Formula taking from website[2]
                B = B * 1000; // Tesla
                F = (B * B * A) / (2 * uo); // Force added. Formula taking from wikipedia[1]
                Vector3 dir = magnetObj.transform.position - metalObject.transform.position;  // Force direction
                metalObject.GetComponent<Rigidbody>().AddForce(F * dir * forceConstant); // make smooth pulling
            }
            else // adjust color  
            {
                metalObject.GetComponent<Renderer>().material.color = c;
            }
          
        }
        
    }

}


