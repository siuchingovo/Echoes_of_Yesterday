using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeCameraCtrl : MonoBehaviour
{
    public Transform playerCamera;
    public Transform playerDefaultViewPoint;
    // public Transform Room2Camera;
    // private Quaternion Room1Rotate;
    public Transform Room2ViewPoint;
    public Transform Picture;
    private Vector3 player_to_photo;
    private Quaternion Room1toRoom2Dir;
    // private Vector3 Room2Pos;
    // Start is called before the first frame update
    void Start()
    {
        // Room1Rotate = playerCamera.rotation;
        Room1toRoom2Dir = Quaternion.FromToRotation(Picture.position - playerDefaultViewPoint.position, Room2ViewPoint.forward);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 player_offset = playerCamera.position - playerDefaultViewPoint.position;
        transform.position = Room2ViewPoint.position + Room1toRoom2Dir * player_offset;

        // Vector3 player_view_rotate = playerCamera.forward;
        transform.forward = Room1toRoom2Dir * playerCamera.forward;
    }
}
