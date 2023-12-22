using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using PathCreation.Examples;


public class SelfDraw : MonoBehaviour
{
    public GameObject pathPointPrefab;
    public List<Transform> mainPathPoints;
    public List<List<Transform>> pathList;
    public List<Transform> path1Points;
    public List<Transform> path2Points;
    public List<Transform> path3Points;
    // public List<Transform> path4Points;
    // public List<Transform> path5Points;
    // public List<Transform> virtualPathPoints;
    public Transform newestPoint;
    public Transform pathPointsHolder;
    public PathCreator pathCreator;
    public RoadMeshCreator roadMeshCreator;

    public OVRInput.Controller controller;
    public Transform rightHandAnchor;

    public bool canDraw;
    public int pathNum;
    public bool canMergePath;
    
    void Start()
    {
        mainPathPoints = new List<Transform>(path1Points);
        pathNum = 2;
        canMergePath = false;

        pathList = new List<List<Transform>>();
        pathList.Add(path1Points);
        pathList.Add(path2Points);
        pathList.Add(path3Points);
        
        canDraw = true;

        UpdatePath();
    }


    // Update is called once per frame
    void Update()
    {
        // if (canDraw && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller)) {
        //     virtualPathPoints = new List<Transform>();
        //     List<Transform> lastThreePoints = pathPoints.GetRange(pathPoints.Count - 3, 3);
        //     virtualPathPoints.AddRange(lastThreePoints);
        //     virtualPathPoints.Add(lastVirtualPoint.transform);
        //     print("virtualPathPoints.Count: " + virtualPathPoints.Count);
        // }

        // When the Forefinger is holding and pressing the Trigger button
        if (canDraw && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, controller)) {
            TrackControllerPosition();
        }

        
        // When the Forefinger release the Trigger button
        if (canDraw && OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, controller)) {
            if(canMergePath)
            {
                MergePath();
            }
            else
            {
                DrawPoint(newestPoint.position);
            }
        }
        
        // If the Thumb press the Trigger button
        if (canDraw && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, controller)) {
            print("Thumb pressed");
            ErasePoint();
        }

        if (canDraw && OVRInput.GetDown(OVRInput.Button.One, controller)) {
            print("A pressed");
        }

        // if (canDraw && Input.GetKeyDown(KeyCode.Space)) {
        //     DrawPoint(transform.position);
        // }
    }

    private void TrackControllerPosition()
    {
        // Update the position of newestPoint to the position of Controller
        newestPoint.position = rightHandAnchor.position;
        
        if (pathList.Count < pathNum)
        {
            print("No more path to merge");
            return;
        }
        // if the controller collides with the first element in the pathNum th list, then set canMergePath to true
        if(pathList[pathNum - 1][0].GetComponent<Collider>().bounds.Contains(rightHandAnchor.position))
        {
            print("canMerge");
            canMergePath = true;
            pathList[pathNum - 1][0].GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            print("can not Merge");
            canMergePath = false;
            pathList[pathNum - 1][0].GetComponent<Renderer>().material.color = Color.white;
        }
    }
    // Merge a existed path to mainPathPoints
    private void MergePath() {
        
        if (pathList.Count < pathNum)
        {
            print("No more path to merge");
            return;
        }
        else
        {
            mainPathPoints.AddRange(pathList[pathNum - 1]);
            pathNum += 1;
            canMergePath = false;
            UpdatePath();
        }
    }

    public void DrawPoint(Vector3 position)
    {
        GameObject pathPoint = Instantiate(pathPointPrefab, position, Quaternion.identity, pathPointsHolder);
        mainPathPoints.Add(pathPoint.transform);

        UpdatePath();
    }

    public void ErasePoint()
    {   
        if (mainPathPoints[mainPathPoints.Count-1] == pathList[pathNum - 2][pathList[pathNum - 2].Count - 1])
        {
            pathNum -= 1;
        }
        {
            print("No more point to erase");
            return;
        }

        // Remove the last one point from the end of the list and detroy it
        mainPathPoints.RemoveAt(mainPathPoints.Count - 1);
        Destroy(pathPointsHolder.GetChild(pathPointsHolder.childCount - 1).gameObject);
        
        UpdatePath();
    }

    private void UpdatePath()
    {
        BezierPath bezierPath = new BezierPath(mainPathPoints, isClosed: false, PathSpace.xyz);
        pathCreator.bezierPath = bezierPath; 
        print("Update bezierPath done");
       
        bezierPath.GlobalNormalsAngle = 90f;

        roadMeshCreator.TriggerUpdate();
    }

    // public void DrawVirtualPoint(Vector3 position)
    // {
       
    //     virtualPathPoints[virtualPathPoints.Count - 1].transform.position = position; // 將路徑點的變換元素添加到路徑點列表中


    //     // 創建一個新的貝塞爾曲線路徑，使用路徑點列表作為控制點，isClosed 參數表示路徑是否封閉，PathSpace 表示路徑的坐標空間
    //     BezierPath bezierPath = new BezierPath(pathPoints, isClosed: false, PathSpace.xyz);
    //     pathCreator.bezierPath = bezierPath; // 將貝塞爾曲線路徑分配給路徑創建器
    //     print("Virtual BezierPath Done");
       
    //     // 設置貝塞爾曲線路徑的全局旋轉角度
    //     bezierPath.GlobalNormalsAngle = 90f;


    //     // 調用 Road Mesh Creator 中的 PathUpdated 方法以重新生成道路網格
    //     roadMeshCreator.TriggerUpdate();


    //     // 添加一個新的路徑點到路徑的末尾（已被註解掉的部分）
    //     // pathCreator.bezierPath.AddSegmentToEnd(position);
    // }
}
