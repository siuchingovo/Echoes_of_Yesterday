using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public GameObject Parent;
    private int index = 0;
    private int indexMax = 0;
    public GameObject currentStaff;
    public float forwardSpeed = 0.1f; 
    public float rotateSpeed = 0.05f; 

    // Start is called before the first frame update
    void Start()
    {
        currentStaff = Parent.transform.GetChild(0).gameObject;
        indexMax = Parent.transform.childCount -1;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(this.transform.position, currentStaff.transform.position);
        if(dist < 0.05f) {
            if( indexMax > index) {
                index++;
                currentStaff = Parent.transform.GetChild(index).gameObject;
            }
        }
        
        Vector3 interpolatedPosition = Vector3.Lerp(this.transform.position, currentStaff.transform.position, 0.05f);
        this.transform.position = interpolatedPosition;
        // new Vector3(interpolatedPosition.x, this.transform.position.y, interpolatedPosition.z);
        transform.rotation = Quaternion.Lerp(this.transform.rotation, currentStaff.transform.rotation, rotateSpeed);
    }
}
