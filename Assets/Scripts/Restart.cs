using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    GameObject button;
   public void RestartLevel() // restart level
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void Start()
    {
        button = GameObject.Find("RestartButton");
        button.SetActive(false);  // we do not want to see initially.
    }
}
