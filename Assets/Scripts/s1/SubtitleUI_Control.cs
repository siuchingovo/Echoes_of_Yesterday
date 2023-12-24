using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleUI_Control : MonoBehaviour
{
    public MeshRenderer subtitle_obj;
    public Texture2D[] subtitles;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSubtitle(int id)
    {
        subtitle_obj.material.SetTexture("_BaseMap", subtitles[id]);
    }

}
