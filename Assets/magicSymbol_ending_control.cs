using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicSymbol_ending_control : MonoBehaviour
{
    public Transform player;
    public Transform whiteRm_pos;
    public S2_SceneManager s2_Manager;

    public GameObject player_quad;
    public fadeScreen quad_fade;

    void Start()
    {
        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.gameObject.tag == "NoteDetector")
        {
            StartCoroutine(endGame());
              
        }
    }

    public IEnumerator endGame()
    {
        //Fade the screen to white================
        player_quad.SetActive(true);
        // yield return new WaitForSeconds(0.5f);
        
        yield return new WaitForSeconds(1f);
        quad_fade.FadeIn();
        //Change Player Pos & set player's parent to null======= 
        player.position = whiteRm_pos.position;
        player.rotation = whiteRm_pos.rotation;
        player.parent = null; 

        s2_Manager.playEnding();
    }
}
