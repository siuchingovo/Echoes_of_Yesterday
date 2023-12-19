using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCollect : MonoBehaviour
{
    public bool[] bear_hand = new bool[2];
    public Animator note_animator;
    
    void Start()
    {
        note_animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (bear_hand[0] == true && bear_hand[1] == true)
        {
            StartCoroutine(noteDisappear());
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlayerHand_L")
        {
            bear_hand[0] = true;
        }
        else if (other.gameObject.tag == "PlayerHand_R")
        {
            bear_hand[1] = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlayerHand_L")
        {
            bear_hand[0] = false;
        }
        else if (other.gameObject.tag == "PlayerHand_R")
        {
            bear_hand[1] = false;
        }
    }
    IEnumerator  noteDisappear()
    {
        Debug.Log("Note Get!!");
        note_animator.SetTrigger("Dead_2");
         yield return new WaitForSeconds(2.05f);
        Destroy(this.gameObject);
    }
}