using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public bool isMagnetActive;
    public GameObject noteDetectorObj;

    void Start()
    {
        noteDetectorObj = GameObject.FindGameObjectWithTag("NoteDetector");
        noteDetectorObj.SetActive(true); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isMagnetActive == true)
        {
            if (other.gameObject.tag == "PlayerCollider")
            {
                Destroy(gameObject);
            }
        }
    }

}
