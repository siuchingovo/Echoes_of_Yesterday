using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comic_Control : MonoBehaviour
{
    public MeshRenderer picture;
    public Texture2D[] comics;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void setComicImg(int id)
    {
        picture.material.SetTexture("_Texture2D", comics[id]);
    }
}
