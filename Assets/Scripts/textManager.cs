using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textManager : MonoBehaviour
{
    GameObject hole;
    GameObject textUI;
    // Start is called before the first frame update
    GameObject[] metalObjects;
    HoleScript holeS;
    bool allOfThemAreGreen;
    void Start()
    {
        hole = GameObject.Find("HoleObject");
        holeS = hole.GetComponent<HoleScript>();
        textUI = gameObject;
        metalObjects = GameObject.FindGameObjectsWithTag("MetalObject");
    }

    // Update is called once per frame
    void Update()  // manage text for giving information about game
    {
        allOfThemAreGreen = true;
        foreach (GameObject metal in metalObjects)  // all objects being magnetized
        {
            if(!(metal.GetComponent<Renderer>().material.GetColor("_Color") == Color.green))
            {
                allOfThemAreGreen = false;
            }
        }
        if (allOfThemAreGreen)
        {  // then set text 
            textUI.GetComponent<UnityEngine.UI.Text>().text = "Now you need to go to the black hole";
        }
        if (holeS.holeIsEntered)
        {  // If level is finished then set text
            textUI.GetComponent<UnityEngine.UI.Text>().text = "If you want to restart please click red button below";
        }
    }
}
