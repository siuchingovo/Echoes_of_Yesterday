using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using PathCreation.Examples;

public class TouchDrawPath : MonoBehaviour
{
    public GameObject pathPointPrefab; // 路徑點的預置物件
    public List<Transform> pathPointsList; // 存儲路徑點的列表
    public PathCreator pathCreator1; // 路徑創建器，用於創建貝塞爾曲線路徑
    public Transform section1Transform;
    public List<Transform> section1List;
    public PathCreator pathCreator2;
    public Transform section2Transform;
    public List<Transform> section2List;
    public PathCreator pathCreator3;
    public Transform section3Transform;
    public List<Transform> section3List;

    public RoadMeshCreator roadMeshCreator1; // 參考 Road Mesh Creator 腳本
    public RoadMeshCreator roadMeshCreator2;
    public RoadMeshCreator roadMeshCreator3;
    // public OVRInput.Controller controller; // 設置控制器
    // // public Transform rightHandAnchor; // 右手錨點
    public bool canDraw;
    public MRTrainController trainController;

    public Transform player;
    public Vector3 playerOriginalPostion;
    public Quaternion playerOriginalRotation;
    public bool onTrain;
    public float positionUpOffset;

    // public EasyMovementController easyMovementController;
    
    // =============William's code================
    // public List<Transform> section3List;
    public List<Transform> touchPathPoints;
    private int sec3Idx;
    private int touchIdx;
    public List<Transform> tmpPathPoints;
    // public RoadMeshCreator roadMeshCreator3;

    public OVRInput.Controller controller;
    public Transform rightHandAnchor;

    // Start is called before the first frame update
    void Start()
    {
        //pathPointsList = new List<Transform>(); // 初始化路徑點列表

        for(int i=0;i<section1Transform.childCount;i++)
        {
            section1List.Add(section1Transform.GetChild(i));
        }
        for(int i=0;i<section2Transform.childCount;i++)
        {
            section2List.Add(section2Transform.GetChild(i));
        }
        for(int i=0;i<section3Transform.childCount;i++)
        {
            section3List.Add(section3Transform.GetChild(i));
        }

        // canDraw = true;
        // onTrain = false;

        // 繪製路徑點的方法

        // BezierPath bezierPath1 = new BezierPath(section1List, isClosed: false, PathSpace.xyz);
        // pathCreator1.bezierPath = bezierPath1; 
        // // bezierPath1.GlobalNormalsAngle = 90f;

        // BezierPath bezierPath2 = new BezierPath(section2List, isClosed: false, PathSpace.xyz);
        // pathCreator2.bezierPath = bezierPath2; 
        // // bezierPath2.GlobalNormalsAngle = 90f;

        // BezierPath bezierPath3 = new BezierPath(section3List, isClosed: false, PathSpace.xyz);
        // pathCreator3.bezierPath = bezierPath3; 
        // bezierPath3.GlobalNormalsAngle = 90f;

        // roadMeshCreator1.TriggerUpdate();
        // roadMeshCreator2.TriggerUpdate();
        // roadMeshCreator3.TriggerUpdate();
        
        // =============William's code================
        sec3Idx = 0;
        touchIdx = 0;
    }


    // Update is called once per frame
    void Update()
    {
        // if (canDraw && Input.GetKeyDown(KeyCode.Space)) { // 如果按下空格鍵
        //     DrawPoint(transform.position); // 呼叫 DrawPoint 方法，繪製路徑點
        // }
        // if (canDraw && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller)) { // 如果按下空格鍵
        //     DrawPoint(rightHandAnchor.position); // 呼叫 DrawPoint 方法，繪製路徑點
        // }
        // if (OVRInput.GetDown(OVRInput.Button.One, controller)) { // 如果按下空格鍵
        //     canDraw = false;
        //     trainController.StartRiding();
        // }
        // if (OVRInput.GetDown(OVRInput.Button.Two, controller)) { // 如果按下空格鍵
        //     // TODO : change viewpoint
        //     if (onTrain) { // from train to audience
        //         player.position = playerOriginalPostion;
        //         player.rotation = playerOriginalRotation;
        //         player.transform.parent = null;
        //         onTrain = false;
        //         trainController.transform.Find("Model").gameObject.SetActive(true);
        //         easyMovementController.enableControl = true;
        //     } else { // from audience to train
        //         playerOriginalPostion = player.position;
        //         playerOriginalRotation = player.rotation;
        //         player.position = trainController.transform.position + trainController.transform.up * positionUpOffset;
        //         player.forward = trainController.transform.forward;
        //         player.transform.parent = trainController.transform;
        //         onTrain = true;
        //         trainController.transform.Find("Model").gameObject.SetActive(false);
        //         easyMovementController.enableControl = false;
        //     }
        // }
        if (Input.GetKeyDown(KeyCode.Space) || (OVRInput.Get(OVRInput.Button.One, controller))) { // 如果按下空格鍵 or A
            canDraw = false;
            trainController.StartRiding();
        }

        if (Input.GetKeyDown(KeyCode.B) || (OVRInput.Get(OVRInput.Button.Two, controller))) { // 如果按下B either on controller or keyboard
            // TODO : change viewpoint
            if (onTrain) { // from train to audience
                player.position = playerOriginalPostion;
                player.rotation = playerOriginalRotation;
                player.transform.parent = null;
                onTrain = false;
                trainController.transform.Find("Model").gameObject.SetActive(true);
                // easyMovementController.enableControl = true;
            } else { // from audience to train
                playerOriginalPostion = player.position;
                playerOriginalRotation = player.rotation;
                player.position = trainController.transform.position - trainController.transform.right * positionUpOffset;
                player.forward = trainController.transform.forward;
                player.transform.parent = trainController.transform;
                onTrain = true;
                trainController.transform.Find("Model").gameObject.SetActive(false);
                // easyMovementController.enableControl = false;
            }
        }

        // =============William's code================
        
        // When the Forefinger is holding and pressing the Trigger button
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, controller)) {
            TrackControllerPosition();
        }

        // When the Forefinger release the Trigger button
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, controller)) {
            print("====GetUp and UpdatePath");
            // touchPathPoints[touchIdx].SetActive(false);
            // touchPathPoints[touchIdx+1].SetActive(true);
            tmpPathPoints = new List<Transform>(section3List.GetRange(0, sec3Idx+1));
            UpdatePath();
            
        }

    }
    // ===================William's code===================
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
                //Use touchPathPoints[i] to get the index in section3List
                touchIdx = i;
                sec3Idx = section3List.IndexOf(touchPathPoints[i]);
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
        pathCreator3.bezierPath = bezierPath; 
        print("Update bezierPath done");
       
        bezierPath.GlobalNormalsAngle = 90f;

        roadMeshCreator3.TriggerUpdate();
    }

   
}
