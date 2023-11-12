using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture_control : MonoBehaviour
{
    public float pic_value = -1.1f;
    public int pictureNum;
    public bool[] quest;
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
        if(quest[0] == true)
        {
            if ((faceManager.lip_down_L + faceManager.lip_down_R)/2 > 0.0f) //Sad face -> Lip Corner Pull Down
            {
                lip_value = (faceManager.lip_down_L + faceManager.lip_down_R)/2;
                
                pic_value += lip_value*0.025f;
                pic_mat.SetFloat("_cutOffHeight", pic_value);
                
            }
        }
    }
}
