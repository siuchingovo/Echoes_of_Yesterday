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
                // trnsform.position += headTransform.right * -0.1f;
                Vector3 newPosition = transform.position + headTransform.right * -0.1f;
                if (CheckPointInsideCollider(newPosition))
                {
                    transform.position = newPosition;
                }
            }
            if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, rightController).x > 0.5f) { 
                print("right");
                // transform.position += headTransform.right * 0.1f;
                Vector3 newPosition = transform.position + headTransform.right * 0.1f;
                if (CheckPointInsideCollider(newPosition))
                {
                    transform.position = newPosition;
                }
            }
            // move forward backward
            if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, rightController).y < -0.5f) { 
                print("back");
                // transform.position += headTransform.forward * -0.1f;
                Vector3 newPosition = transform.position + headTransform.forward * -0.1f;
                if (CheckPointInsideCollider(newPosition))
                {
                    transform.position = newPosition;
                }
            }
            if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, rightController).y > 0.5f) { 
                print("forward");
                // transform.position += headTransform.forward * 0.1f;
                Vector3 newPosition = transform.position + headTransform.forward * 0.1f;
                if (CheckPointInsideCollider(newPosition))
                {
                    transform.position = newPosition;
                }
            }
        }
    }
    public bool CheckPointInsideCollider(Vector3 point) {
        if (Physics.CheckSphere(point, 0.01f, LayerMask.GetMask("DrawBounds")))
        {
            print("point is inside");
            // other.gameObject.GetComponent<Renderer>().material.color = Color.green;
            return true;
        }
        else
        {
            print("point is outside");
            // other.gameObject.GetComponent<Renderer>().material.color = Color.red;
            return false;
        }
    }
}
