using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbol_control : MonoBehaviour
{
    public MR_SceneManager mr_manager;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerHand_R")
        {
            mr_manager.startComic();
        }
    }
}
