using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Control : MonoBehaviour
{
    public Animator slime_animator;

    void Start()
    {
        slime_animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }

    public void jump(bool status)
    {
        slime_animator.SetBool("isJump", status);
    }
}
