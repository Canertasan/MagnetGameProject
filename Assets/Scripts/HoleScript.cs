using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class HoleScript : MonoBehaviour
{
    int total;
    public List<Collider> gameObjects = new List<Collider>();
    GameObject gObj;
    GameObject hole;
    GameObject button;
    GameObject[] metalObjects;
    public bool holeIsEntered;
    // Start is called before the first frame update
    void Start()
    {
        metalObjects = GameObject.FindGameObjectsWithTag("MetalObject");
        total = metalObjects.Count() + 1; // all metals and 1 magnet
        gObj = GameObject.Find("CubeMagnet");
        hole = GameObject.Find("HoleObject");
        button = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("restartButton"));
    }


    
    private void OnTriggerEnter(Collider other)
    {  // if hole is collide with all metals and magnets
        if (!gameObjects.Contains(other))
        {
            gameObjects.Add(other);
        }
        
        if (gameObjects.Count() == total)  // if collide with all objects(metal and magnet)
        { //then set bool true for text and show Button UI
            holeIsEntered = true;
            button.SetActive(true);
            gameObjects.Clear();
        }
    }
}
