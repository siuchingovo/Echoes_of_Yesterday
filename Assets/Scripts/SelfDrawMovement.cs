using UnityEngine;

public class SelfDrawMovement : MonoBehaviour
{
    public OVRInput.Controller controller;
    public float moveSpeed = 3.0f;

    public Collider movementBounds;

    void Start()
    {
        movementBounds = GetComponent<Collider>();
    }

    void Update()
    {
        float horizontalInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, controller).x;
        float verticalInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, controller).y;

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput) * moveSpeed * Time.deltaTime;

        Vector3 targetPosition = transform.position + movement;

        if (IsWithinBounds(targetPosition))
        {

            transform.Translate(movement);
        }
    }

    bool IsWithinBounds(Vector3 position)
    {
        RaycastHit hit;
        return Physics.Raycast(position, Vector3.down, out hit) && hit.collider == movementBounds;
    }
}
