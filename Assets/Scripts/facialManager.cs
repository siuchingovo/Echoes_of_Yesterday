using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facialManager : MonoBehaviour
{
    public bool getData = true;
    public OVRFaceExpressions AvatarFace;

    [Header("Sad")]
    public float lip_down_L;
    public float lip_down_R;

    [Header("Happy")]
    public float Lip_corner_Up_L; //if user smiling====

    void Start()
    {
        
    }


    void Update()
    {
        if (getData)
        {
            lip_down_L = AvatarFace.expression30_value;
            lip_down_R = AvatarFace.expression30_value;
            if ((lip_down_L + lip_down_R)/2 <= 0.1f)
            {
                lip_down_L = lip_down_R = 0.0f;
            }
        }


    }
}
