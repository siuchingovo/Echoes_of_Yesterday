using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facialManager : MonoBehaviour
{
    public bool getFacialData = true;
    public OVRFaceExpressions AvatarFace;
    public float Lip_corner_Up_L; //if user smiling====

    void Start()
    {
        
    }


    void Update()
    {
        if (getFacialData)
        {
            Lip_corner_Up_L = AvatarFace.expression32_value;
            if (Lip_corner_Up_L <= 0.1f)
            {
                Lip_corner_Up_L = 0.0f;
            }
        }


    }
}
