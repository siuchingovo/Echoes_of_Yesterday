using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform exitPoint;
    
    void OnTriggerStay(Collider other)
    {
        print("inside portal");
        if (other.CompareTag("Player"))
        {
            other.transform.position = exitPoint.position;
        }
    }

}
