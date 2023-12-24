using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameInstruct_UI_Control : MonoBehaviour
{
    public OVRInput.Controller controller;
    public SubtitleUI_Control gameInstruct_UI;
    public int subtitle_id = 0;

    public GameObject GameInstruct_obj;
    public PlayableDirector UI_fade;
    public bool played;

    public TouchDrawPath touchDrawPath;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (!played)
        {
            if (OVRInput.GetDown(OVRInput.Button.One, controller)) //RightController Button A========
            {
                if (subtitle_id < gameInstruct_UI.subtitles.Length)
                {
                    subtitle_id ++;
                    gameInstruct_UI.setSubtitle(subtitle_id);
                }
                else if (subtitle_id > gameInstruct_UI.subtitles.Length-1)
                {
                    touchDrawPath.easyMovementController.enableControl = true;
                    StartCoroutine(fade_destroy());
                }
            }
        }

    }

    public IEnumerator fade_destroy()
    {
        UI_fade.Play();
        yield return new WaitForSeconds(1.0f);
        played = true;
        Destroy(GameInstruct_obj);
        
        
    }
}
