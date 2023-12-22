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
    public int currentPathPointIndex;
    // Start is called before the first frame update
    void Start()
    {
        isRiding = false;
        distanceTravelled = 0f;
        StartRiding();
    }

    // Update is called once per frame
    void Update()
    {
        while (currentPathPointIndex + 1 < pathCreator.path.localPoints.Length && pathCreator.path.GetClosestDistanceAlongPath(pathCreator.path.GetPoint(currentPathPointIndex)) <= distanceTravelled) {
            currentPathPointIndex += 1;
        }
        if (pathCreator != null && isRiding)
        {
            speed = Vector3.Distance(pathCreator.path.GetPoint(currentPathPointIndex), pathCreator.path.GetPoint(currentPathPointIndex - 1)) / (60f/(54f * 3f / 4f * 3f));
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            // transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction) * Quaternion.Euler(90, 0, 90);  // 我改回來了ㄏ 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        }
    }
    
    public void StartRiding()
    {
        isRiding = true;
        transform.Find("Model").gameObject.SetActive(true); 
    }
}
