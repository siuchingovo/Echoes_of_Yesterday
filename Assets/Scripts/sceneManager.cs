using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public GameObject player_cam;
    public Transform[] player_perspectives;

    public fadeScreen fadeScreen;
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1)) // to girl 1
        {
            StartCoroutine(ChangePersp(0));
            // player_cam.transform.position = player_perspectives[0].transform.position;
            
        }

        if (Input.GetKeyUp(KeyCode.Alpha2)) //to kuma 2
        {
            StartCoroutine(ChangePersp(1));
            // player_cam.transform.position = player_perspectives[1].transform.position;
        }
    }


    IEnumerator ChangePersp(int id)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
        player_cam.transform.position = player_perspectives[id].transform.position;

        fadeScreen.FadeIn();
    }

}
