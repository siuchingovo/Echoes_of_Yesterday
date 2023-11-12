using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture_control : MonoBehaviour
{
    public float pic_value = -1.1f;
    public int pictureNum;
    public bool[] quest;
    public facialManager faceManager;
    // public Material pic_mat;
    private float lip_value;

    void Start()
    {
        // pic_mat = GetComponent<MeshRenderer>().material;
    }

    
    void Update()
    {
        if(quest[0] == true)
        {
            lip_value = (faceManager.lip_down_L + faceManager.lip_down_R)/2; //Sad face -> Lip Corner Pull Down
            if (lip_value > 0.0f) 
            {
                
                
                // pic_value += lip_value*0.025f;
                // pic_mat.SetFloat("_cutOffHeight", pic_value);
                
            }
        }
    }
}
