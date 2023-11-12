using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture_control : MonoBehaviour
{
    public float pic_value = -1.2f;
    public bool[] quest;
    public facialManager faceManager;
    public MeshRenderer[] pic_mat;
    private float lip_value;
    void Start()
    {

    }

    
    void Update()
    {
        if(quest[0] == true)
        {
            lip_value = ((faceManager.Lip_Down_L + faceManager.Lip_Down_R) / 2);
            if (lip_value > 0.0f)
            {
                pic_value += lip_value*0.025f;
                pic_mat[0].material.SetFloat("_cutOffHeight", pic_value);
                
                if (pic_value > 0.06f)
                {
                    SetQuestFalse(0);
                }
            }
            
            
        }
    }

    public void SetQuestTrue(int value)
    {
        quest[value] = true;
    }
    
    
    public void SetQuestFalse(int value)
    {
        quest[value] = false;
    }


}
