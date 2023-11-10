using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Picture_Event : MonoBehaviour
{
    public string target_tag;
    public bool touched;
    public PlayableDirector[] picture_timeline;

    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == target_tag)
        {
            touched = true;
            // picture_timeline[0].Play();
        }
    }
}
