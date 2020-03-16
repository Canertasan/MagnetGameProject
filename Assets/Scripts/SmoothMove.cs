using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMove : MonoBehaviour
{
    int counter = 0;
    GameObject planeWater;
    Vector3 newVec = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {  // water object
        planeWater = gameObject;
    }

    // Update is called once per frame
    void Update()
    {  // for sea going up and down slowly.
        if(counter == 0 && planeWater.transform.position.y > -0.2 && planeWater.transform.position.y < 0.3)
        {  // going up with transformation
            newVec.Set(planeWater.transform.position.x ,(planeWater.transform.position.y + 0.003f), planeWater.transform.position.z);
            planeWater.transform.position = newVec;
        }
        else
        {  // going down with transformation
            counter++;
            newVec.Set(planeWater.transform.position.x, (planeWater.transform.position.y - 0.003f), planeWater.transform.position.z);
            planeWater.transform.position = newVec;
            if(counter == 118)
            {
                counter = 0;
            }
        }
    }
}
