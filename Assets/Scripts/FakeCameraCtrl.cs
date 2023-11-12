using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeCameraCtrl : MonoBehaviour
{
    public Transform playerCamera;
    // public Transform Room2Camera;
    private Vector3 Room1Pos;
    private Quaternion Room1Rotate;
    public Transform Room2ViewPoint;
    public Transform PictureViewPoint;
    private Vector3 Room2Pos;
    // Start is called before the first frame update
    void Start()
    {
        // Room1Pos = playerCamera.position;
        // Room1Pos = new Vector3(1.15f,0.8f,0.485f);
        // Room1Rotate = playerCamera.rotation;
        // Room1Pos.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
        // Room2Pos = new Vector3(0.145f,0.54f,8.371f);
        // Room2Pos.rotation = Quaternion.Euler(new Vector3(0f,-58.30f,0f));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 player_offset = playerCamera.position - PictureViewPoint.position;
        transform.position = Room2ViewPoint.position + player_offset;

        float angularDiff = Quaternion.Angle(playerCamera.rotation, PictureViewPoint.rotation);
        // float angularDiff = Quaternion.Angle(Quaternion.Euler(new Vector3(0f, 90f, 0f)), Quaternion.Euler(new Vector3(0f,-58.30f,0f)));

        Quaternion RoomRotationDiff = Quaternion.AngleAxis(angularDiff, Vector3.up);
        Vector3 newCameraDir = RoomRotationDiff * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDir, Vector3.up);
        // Debug.Log(Quaternion.LookRotation(newCameraDir, Vector3.up));
    }
}
