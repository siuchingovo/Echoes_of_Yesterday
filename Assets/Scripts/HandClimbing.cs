using UnityEngine;

public class HandClimbing : MonoBehaviour
{
    public Rigidbody playerRigRigibody;
    public Transform playerRigTransform;

    private Vector3 prevHandPosition = Vector3.zero;
    public Vector3 Delta { private set; get; } = Vector3.zero;
    private bool isGrabbing = false;
    void Start()
    {
        prevHandPosition = transform.position;
    }

    void Update()
    {
        Delta = transform.position - prevHandPosition;
        if(isGrabbing)
        {
            print("camera moving");
            playerRigTransform.position -= new Vector3(0f, Delta.y*0.6f, 0f);
        }
        prevHandPosition = transform.position;

    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("ClimbObject"))
        {
            isGrabbing = true;
            playerRigRigibody.isKinematic = true;
            other.GetComponent<MeshRenderer>().material.color = Color.blue;
            print("climbing");
        }
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("TableDesktop"))
    //     {
    //         // isMovingToDesktop = true;
    //         // other.GetComponent<MeshRenderer>().material.color = Color.yellow;
    //         // while(playerRigTransform.position.y <= 3.2f)
    //         // {
    //         //     playerRigRigibody.isKinematic = true;
    //         //     playerRigTransform.position += new Vector3(0f, 0.01f, 0f); 
    //         // }
    //         // playerRigRigibody.isKinematic = false;
    //     }
    // }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ClimbObject"))
        {
            isGrabbing = false;
            playerRigRigibody.isKinematic = false;
            other.GetComponent<MeshRenderer>().material.color = Color.grey;
        }
        // else if (other.CompareTag("TableDesktop"))
        // {
        //     isGrabbing = false;
        //     other.GetComponent<MeshRenderer>().material.color = Color.gray;
                        
        // }
    }
}
