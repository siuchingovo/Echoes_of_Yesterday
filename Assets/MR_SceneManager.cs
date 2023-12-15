using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MR_SceneManager : MonoBehaviour
{
    public PlayableDirector timeline_start;
    
    void Start()
    {
        StartCoroutine(playStartTimeline());
    }

    
    void Update()
    {
        
    }



    //==========================================
    IEnumerator playStartTimeline()
    {
        yield return new WaitForSeconds(2.0f);

        timeline_start.Play();
    }
}
