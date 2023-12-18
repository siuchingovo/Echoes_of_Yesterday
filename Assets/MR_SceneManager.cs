using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MR_SceneManager : MonoBehaviour
{
    [Header("Timeline")]
    public PlayableDirector timeline_start;
    public PlayableDirector timeline_comic;
    
    [Header("Intro")]
    public MeshRenderer picture;
    public Texture2D[] comics;

    void Start()
    {
        StartCoroutine(playStartTimeline());
    }

    
    void Update()
    {


        //ShortCut=========
        if (Input.GetKeyUp(KeyCode.Alpha1)){
            startComic();
        }
    }



    //==========================================
    IEnumerator playStartTimeline()
    {
        yield return new WaitForSeconds(2.0f);

        timeline_start.Play();
    }

    public void startComic()
    {
        timeline_comic.Play();
    }

    public void setComicImg(int id)
    {
        picture.material.SetTexture("_Texture2D", comics[id]);
    }
}
