using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{
    enum Polarization
    {
        Negative = 0,
        Positive = 1
    }
    //GameObject magnetCube;
    //Doesn't understand why i need enum type called Polarization that can be negative or positive.
    //I did not understand specific places, for ex. magnets have + - at the same time, so magnets can be push or pull in terms of positions.
    //https://www.youtube.com/watch?v=Mp0Bu75MSj8
    //Also without second magnet game is more sense.
    //I already applied force to metal objects in MetalScript.cs. 
    void Start()
    {
        //magnetCube = GameObject.FindGameObjectWithTag("Draggable");
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
