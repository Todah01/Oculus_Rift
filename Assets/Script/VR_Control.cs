﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_Control : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetViberate();
    }
    void SetViberate()
    {
        OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.LTouch);
        //OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);
    }
}
