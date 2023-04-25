using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RController : MonoBehaviour
{
    public GameObject grabobj;
    public Transform grabpos;

    bool iscontact = false;
    // Start is called before the first frame update
    void Start()
    {
        iscontact = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TouchObj()
    {
        OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabable") == true)
        {
            iscontact = true;
            grabobj = other.gameObject;
        }
        if (other.CompareTag("Moveable") == true)
        {
            other.GetComponent<Rigidbody>().AddForce(OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch) * 10f,ForceMode.Force);
        }
        TouchObj();
    }
}
