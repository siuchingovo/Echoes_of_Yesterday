using UnityEngine;

public class SelfDrawMovement : MonoBehaviour
{
    public OVRInput.Controller controller;
    public float movementSpeed = 3.0f;

    private bool isWithinBounds;

    void Update()
    {
        Vector3 headForward = transform.forward.normalized;
        Vector3 headRight = transform.right.normalized;

        Vector2 stickInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, controller);

        Vector3 moveDirection = headForward * stickInput.y +  headRight * stickInput.x;

        moveDirection.Normalize();
        // print("isWithinBounds" + isWithinBounds);
        // Vector3 prev_position = transform.position;
        Vector3 newPosition = transform.position + moveDirection * movementSpeed * Time.deltaTime;
        if (CheckPointInsideCollider(newPosition))
        {
            transform.position = newPosition;
        }
        // transform.position = newPosition;
        // if (!isWithinBounds)
        // {
        //     print("comeback from" + transform.position + "to" + prev_position);
        //     transform.position = prev_position;
        // }
    }
    // //when the player is within the bounds of the collider
    // void OnTriggerStay(Collider other)
    // {
    //     if (other.gameObject.CompareTag("DrawBounds"))
    //     {
    //         //change the color of the gameboject to green
    //         other.gameObject.GetComponent<Renderer>().material.color = Color.green;
    //         isWithinBounds = true;
    //     }
    // }
    // //when the player is outside the bounds of the collider
    // void OnTriggerExit(Collider other)
    // {
    //     if (other.gameObject.CompareTag("DrawBounds"))
    //     {
    //         //change the color of the gameboject to red
    //         other.gameObject.GetComponent<Renderer>().material.color = Color.red;
    //         isWithinBounds = false;
    //     }
    // }
    public bool CheckPointInsideCollider(Vector3 point) {
        if (Physics.CheckSphere(point, 0.01f, LayerMask.GetMask("DrawBounds")))
        {
            print("point is inside");
            // other.gameObject.GetComponent<Renderer>().material.color = Color.green;
            return true;
        }
        else
        {
            print("point is outside");
            // other.gameObject.GetComponent<Renderer>().material.color = Color.red;
            return false;
        }
    }
}