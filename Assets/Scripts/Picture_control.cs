using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture_control : MonoBehaviour
{
    public float pic_value = -1.1f;
    public int pictureNum;
    public bool quest;
    public facialManager faceManager;
    public Material pic_mat;
    private float lip_value;
    private float current_value = -1.1f;
    void Start()
    {
        pic_mat = GetComponent<MeshRenderer>().material;
    }

    
    void Update()
    {
        if(quest)
        {
            if (faceManager.Lip_corner_Up_L > 0.0f)
            {
                lip_value = faceManager.Lip_corner_Up_L;
                
                pic_value += lip_value*0.025f;
                // current_value = pic_value;
                pic_mat.SetFloat("_cutOffHeight", pic_value);
                
            }
            
            
        }
    }
}
