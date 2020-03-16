using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsFixer : MonoBehaviour
{
    // Start is called before the first frame update
    public int target = 60;

    void Awake()  // fix fps if it decreases
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = target;
    }

    void Update()
    {
        if (Application.targetFrameRate < target)
            Application.targetFrameRate = target;
    }

}
