using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class S2_SceneManager : MonoBehaviour
{
    [Header("Timeline")]
    public PlayableDirector ending_timeline;

    public magicSymbol_ending_control endingControl;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        //Shortcut for s2====================
        if (Input.GetKey(KeyCode.Alpha5))
        {
            //Play Ending====================
            endingControl.endGame();
        }
    }

    public void playEnding()
    {
        ending_timeline.Play();
    }

    
    
}
