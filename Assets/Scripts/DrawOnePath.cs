using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using PathCreation.Examples;

public class DrawOnePath : MonoBehaviour
{
    public GameObject pathPointPrefab;
    public List<Transform> mainPathPoints;
    public List<Transform> touchPathPoints;
    private int touchIdx;
    public List<Transform> tmpPathPoints;
    public Transform pathPointsHolder;
    public PathCreator pathCreator;
    public RoadMeshCreator roadMeshCreator;

    public OVRInput.Controller controller;
    public Transform rightHandAnchor;

    public bool canDraw;
    // Start is called before the first frame update
    void Start()
    {
        // mainPathPoints = new List<Transform>();
        // touchPathPoints = new List<Transform>();
        canDraw = false;
    }

    // Update is called once per frame
    void Update()
    {
        // When the Forefinger is holding and pressing the Trigger button
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, controller)) {
            TrackControllerPosition();
        }

        
        // When the Forefinger release the Trigger button
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, controller)) {
            print("====GetUp and UpdatePath");
            UpdatePath();
            
        }
    }
    private void TrackControllerPosition()
    {    
        print("====TrackControllerPosition");
        //check which gameobject in the touchPathPoints collides with  the controller collides, then change the color of the gameobject to green
        for (int i = 0; i < touchPathPoints.Count; i++)
        {
            if(touchPathPoints[i].GetComponent<Collider>().bounds.Contains(rightHandAnchor.position))
            {
                touchPathPoints[i].GetComponent<Renderer>().material.color = Color.green;
                print("=======Inside touchPathPoints[i]" + touchPathPoints[i]);
                //Use touchPathPoints[i] to get the index in mainPathPoints
                touchIdx = mainPathPoints.IndexOf(touchPathPoints[i]);
                tmpPathPoints = new List<Transform>(mainPathPoints.GetRange(0, touchIdx+1));
            }
            else
            {
                touchPathPoints[i].GetComponent<Renderer>().material.color = Color.white;
                print("=======Outside touchPathPoints[i]" + touchPathPoints[i]);
            }
        }
    }

    private void UpdatePath()
    {
        BezierPath bezierPath = new BezierPath(tmpPathPoints, isClosed: false, PathSpace.xyz);
        pathCreator.bezierPath = bezierPath; 
        print("Update bezierPath done");
       
        bezierPath.GlobalNormalsAngle = 90f;

        roadMeshCreator.TriggerUpdate();
    }
}
