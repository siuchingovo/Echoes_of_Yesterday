using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facialManager : MonoBehaviour
{
    public bool getFacialData = true;
    public OVRFaceExpressions AvatarFace;
    public float Lip_corner_Up_L; //if user smiling====
    public float Lip_Down_L;
    public float Lip_Down_R;
    
    void Start()
    {
        
    }


    void Update()
    {
        if (getFacialData)
        {
            Lip_Down_L = AvatarFace.expression30_value;
            Lip_Down_R = AvatarFace.expression31_value;
            if (Lip_Down_L <= 0.1f || Lip_Down_R <= 0.1f)
            {
                Lip_Down_L = 0.0f;
                Lip_Down_R = 0.0f;
            }
        }


    }
}
