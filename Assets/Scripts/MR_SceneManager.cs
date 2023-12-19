using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class MR_SceneManager : MonoBehaviour
{
    [Header("Timeline")]
    public PlayableDirector timeline_start;
    public PlayableDirector timeline_comic;
    public PlayableDirector timeline_slime;
    
    [Header("Intro")]
    public MeshRenderer picture;
    public Texture2D[] comics;

    [Header("Scene GameObject")]
    public GameObject[] scene_obj;

    [Header("Scene Related")]
    public string scene_2;

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

    //timeline=====================================
    public void startComic()
    {

        timeline_comic.Play();
    }

    public void startSlime()
    {

        timeline_slime.Play();
    }

    //Object Settin=================================
    public void setComicImg(int id)
    {
        picture.material.SetTexture("_Texture2D", comics[id]);
    }

    public void setSceneObj(bool status)
    {
        for (int i =0; i < scene_obj.Length; i++)
        {
            scene_obj[i].SetActive(status);
        }
        
    }

    //Load Scene===================================
    public void nextScene()
    {
        SceneManager.LoadScene(scene_2);
    }
}
