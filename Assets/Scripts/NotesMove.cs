using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesMove : MonoBehaviour
{
    NotesControl NotesControl;
    public Magnet magnet;
    public PathCreation.Examples.PathPlacer_yun _path;
    bool magnetActive;

    void Start()
    {
        NotesControl = gameObject.GetComponent<NotesControl>();
        magnet = GameObject.FindGameObjectWithTag("Magnet").GetComponent<Magnet>();
    }

    
    void Update()
    {
        if (magnetActive == true)
        {
            Debug.Log("Magnet is active");
            transform.position = Vector3.MoveTowards(transform.position, NotesControl.playerTransform.position, NotesControl.speed * Time.deltaTime);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (magnet.isMagnetActive == true)
        {
            if (other.gameObject.tag == "PlayerCollider")
            {
                _path = GameObject.FindGameObjectWithTag("NotesHolder").GetComponent<PathCreation.Examples.PathPlacer_yun>();
                _path.TotalScore += transform.parent.GetComponent<PathCreation.Examples.NoteSpawn>().score;
                Destroy(gameObject);
            }
            else if (other.gameObject.tag == "NoteDetector")
            {
                magnetActive = true;
            }
        }
    }
}

