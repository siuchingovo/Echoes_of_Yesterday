using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2Ctrl : MonoBehaviour
{
    public Transform playerCamera;
    public Transform playerDefaultViewPoint;
    // public Transform Room2Camera;
    // private Quaternion Room1Rotate;
    public Transform Room2ViewPoint;
    public Transform Picture;
    private Vector3 player_to_photo;
    private Quaternion Room1toRoom2Dir;

    // public Transform target;


    // Start is called before the first frame update
    void Start()
    {
        // 將 room1 預設向照片看的座標轉成 room2 相機向前的向量
        Room1toRoom2Dir = Quaternion.FromToRotation(Picture.position - playerDefaultViewPoint.position, Room2ViewPoint.forward);
    }

    // Update is called once per frame
    void Update()
    {
        // // Determine which direction to rotate towards
        // Vector3 targetDirection = Picture.position - playerCamera.position;

        // // The step size is equal to speed times frame time.
        // // float singleStep = 0.01f * Time.deltaTime;

        // // Rotate the forward vector towards the target direction by one step
        // Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // // Draw a ray pointing at our target in
        // Debug.DrawRay(transform.position, newDirection, Color.red);

        // // Calculate a rotation a step closer to the target and applies rotation to this object
        // transform.rotation = Quaternion.LookRotation(newDirection);

        Vector3 player_offset = playerCamera.position - playerDefaultViewPoint.position;
        transform.position = Room2ViewPoint.position + Room1toRoom2Dir * player_offset;

        // Vector3 player_view_rotate = playerCamera.forward;
        transform.forward = Room1toRoom2Dir * playerCamera.forward;
        // float angularDiff = Quaternion.Angle(playerCamera.rotation, Picture.rotation);
        // // float angularDiff = Quaternion.Angle(Quaternion.Euler(new Vector3(0f, 90f, 0f)), Quaternion.Euler(new Vector3(0f,-58.30f,0f)));

        // Quaternion RoomRotationDiff = Quaternion.AngleAxis(angularDiff, Vector3.up);
        // Vector3 newCameraDir = RoomRotationDiff * playerCamera.forward;
        // transform.rotation = Quaternion.LookRotation(newCameraDir, Vector3.up);

        if(playerCamera.position == Picture.position){
            playerCamera.position = transform.position;
        }
    }
}
