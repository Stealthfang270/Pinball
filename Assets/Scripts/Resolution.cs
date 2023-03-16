using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Screen.SetResolution(480, 640, false);
        Screen.fullScreen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
