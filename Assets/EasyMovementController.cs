using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EasyMovementController : MonoBehaviour
{
    public Transform headTransform;
    public OVRInput.Controller rightController; // 設置控制器
    public bool enableControl;
    // Start is called before the first frame update
    void Start()
    {
        enableControl = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (enableControl) {
            // move left right
            if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, rightController).x < -0.5f) { 
                print("left");
                transform.position += headTransform.right * -0.1f;
            }
            if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, rightController).x > 0.5f) { 
                print("right");
                transform.position += headTransform.right * 0.1f;
            }
            // move forward backward
            if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, rightController).y < -0.5f) { 
                print("back");
                transform.position += headTransform.forward * -0.1f;
            }
            if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, rightController).y > 0.5f) { 
                print("forward");
                transform.position += headTransform.forward * 0.1f;
            }
        }
    }
}
