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
        // StartRiding();
    }

    // Update is called once per frame
    void Update()
    {
        // print(pathCreator.bezierPath.input_points.Count);
        while (currentPathPointIndex + 1 < pathCreator.bezierPath.input_points.Count && pathCreator.path.GetClosestDistanceAlongPath(pathCreator.bezierPath.input_points[currentPathPointIndex]) <= distanceTravelled) {
            currentPathPointIndex += 1;
        }
        if (pathCreator != null && isRiding)
        {
            speed = Vector3.Distance(pathCreator.bezierPath.input_points[currentPathPointIndex], pathCreator.bezierPath.input_points[currentPathPointIndex - 1]) / (60f/(54f * 3f / 4f * 3f));
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
