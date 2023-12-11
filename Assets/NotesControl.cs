using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesControl : MonoBehaviour
{
    public Transform playerTransform;
    public float speed = 5f;

    NotesMove NotesMove;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("PlayerCollider").transform;
        NotesMove = GetComponent<NotesMove>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NoteDetector")
        {
            NotesMove.enabled = true;
        }
    }
}
