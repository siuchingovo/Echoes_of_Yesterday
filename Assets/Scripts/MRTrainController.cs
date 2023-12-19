using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class MRTrainController : MonoBehaviour
{
    public bool isRiding;
    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;
    public float distanceTravelled;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        isRiding = false;
        distanceTravelled = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (pathCreator != null && isRiding)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        }
    }
    
    public void StartRiding()
    {
        isRiding = true;
        transform.Find("Model").gameObject.SetActive(true); 
    }
}
