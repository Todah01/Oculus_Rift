using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTouch_Control : MonoBehaviour
{
    public Transform GrabPos;

    GameObject Grabobj;

    bool isGrabed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {
        if (isGrabed == true)
        {
            //컨트롤러가 흔들림
            Vector3 shaked = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
            float speed = Vector3.SqrMagnitude(shaked); // 속도 체크 magnitude
            if (speed >= 1.5f)
            {
                Grabobj.GetComponent<Rigidbody>().isKinematic = false;
                Grabobj.transform.SetParent(null);
                isGrabed = false;
                Grabobj = null;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            OVRInput.SetControllerVibration(0.1f, 0.5f, OVRInput.Controller.RTouch); //컨트롤러의 진동발생
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            collision.transform.SetParent(GrabPos);
            Grabobj = collision.gameObject;
            isGrabed = true;
        }
    }
}
