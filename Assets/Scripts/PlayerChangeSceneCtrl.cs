using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeSceneCtrl : MonoBehaviour
{
    public bool canChangeScene;
    public Transform Room2Camera;
    // public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(ExampleCoroutine());

    }

    // Update is called once per frame
    void Update()
    {
        if(canChangeScene){
            transform.position = Room2Camera.position;
            transform.rotation = Quaternion.Euler (0f, -180f, 0f);
            canChangeScene = false;
        }
        
    }

    // IEnumerator ExampleCoroutine()
    // {
    //     //Print the time of when the function is first called.
    //     Debug.Log("Started Coroutine at timestamp : " + Time.time);

    //     //yield on a new YieldInstruction that waits for 5 seconds.
    //     yield return new WaitForSeconds(2);

    //     //After we have waited 5 seconds print the time again.
    //     Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    //     // transform.position = new Vector3(0.145f,0.54f,8.371f);
    //     // transform.rotation = Quaternion.Euler(new Vector3(0f,-58.30f,0f));
    // }

}
