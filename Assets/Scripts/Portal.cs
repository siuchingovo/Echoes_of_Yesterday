using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform exitPoint;
    public GameObject player_camera;
    public GameObject portals_parent;
    public GameObject climb_wall;
    public HandClimbing leftHandClimbing;
    public HandClimbing rightHandClimbing;
    
    void OnTriggerEnter(Collider other)
    {
        print("inside portal");
        if (other.CompareTag("MainCamera"))
        {
            player_camera.transform.position = exitPoint.position;   
        }
    }
    void OnTriggerExit(Collider otehr)
    {
        player_camera.GetComponent<Rigidbody>().isKinematic = false;
        leftHandClimbing.isGrabbing = false;
        rightHandClimbing.isGrabbing = false;
        Destroy(climb_wall);
        Destroy(portals_parent);
    }

}
