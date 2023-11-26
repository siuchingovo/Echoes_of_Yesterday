using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using PathCreation.Examples;

public class PathPointDrawer : MonoBehaviour
{
    public GameObject pathPointPrefab; // 路徑點的預置物件
    public List<Transform> pathPoints; // 存儲路徑點的列表
    public Transform pathPointsHolder; // 存儲路徑點的遊戲物件
    public PathCreator pathCreator; // 路徑創建器，用於創建貝塞爾曲線路徑

    public RoadMeshCreator roadMeshCreator; // 參考 Road Mesh Creator 腳本
    public OVRInput.Controller controller; // 設置控制器
    public Transform rightHandAnchor; // 右手錨點
    public bool canDraw;
    

    // Start is called before the first frame update
    void Start()
    {
        pathPoints = new List<Transform>(); // 初始化路徑點列表
        canDraw = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canDraw && Input.GetKeyDown(KeyCode.Space)) { // 如果按下空格鍵
            DrawPoint(transform.position); // 呼叫 DrawPoint 方法，繪製路徑點
        }
        if (canDraw && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller)) { // 如果按下空格鍵
            DrawPoint(rightHandAnchor.position); // 呼叫 DrawPoint 方法，繪製路徑點
        }
        if (OVRInput.GetDown(OVRInput.Button.One, controller)) { // 如果按下空格鍵
            canDraw = false;
        }
    }

    // 繪製路徑點的方法
    void DrawPoint(Vector3 position)
    {
        // 創建一個新的路徑點遊戲物件並將其實例化到指定位置，並將其作為子物件放入路徑點容器中
        GameObject pathPoint = Instantiate(pathPointPrefab, position, Quaternion.identity, pathPointsHolder);
        pathPoints.Add(pathPoint.transform); // 將路徑點的變換元素添加到路徑點列表中

        // 創建一個新的貝塞爾曲線路徑，使用路徑點列表作為控制點，isClosed 參數表示路徑是否封閉，PathSpace 表示路徑的坐標空間
        BezierPath bezierPath = new BezierPath(pathPoints, isClosed: false, PathSpace.xyz);
        pathCreator.bezierPath = bezierPath; // 將貝塞爾曲線路徑分配給路徑創建器
        print("bezierPath done");
        // 調用 Road Mesh Creator 中的 PathUpdated 方法以重新生成道路網格
        roadMeshCreator.TriggerUpdate();

        // // 添加一個新的路徑點到路徑的末尾（已被註解掉的部分）
        // pathCreator.bezierPath.AddSegmentToEnd(position);
    }
}
