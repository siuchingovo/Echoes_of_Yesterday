using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

namespace PathCreation.Examples {
    public class MRTrainController_yun : MonoBehaviour
    {
        public bool isRiding;
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float distanceTravelled;
        public float speed;
        public PathPlacer_yun pathPlacer;
        public float PathLen;
        public Transform player;
        public float positionUpOffset = 1f;
        public int currentPathPointIndex;
        // public AudioSource m_AudioSource;

        // Start is called before the first frame update
        void Start()
        {
            isRiding = false;
            distanceTravelled = 0f;
            
            
            // StartRiding();
            // speed = 1.912742f;
            // len = pathCreator.path.length;
            // Debug.Log(pathCreator.path.length);
        }

        // Update is called once per frame
        void Update()
        {


            // while (currentPathPointIndex + 1 < pathCreator.bezierPath.input_points.Count && pathCreator.path.GetClosestDistanceAlongPath(pathCreator.bezierPath.input_points[currentPathPointIndex]) <= distanceTravelled) {
            //     currentPathPointIndex += 1;
            // }
            if (pathCreator != null && isRiding)
            {
                Quaternion r = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                // Debug.Log(r.x + " " + r.y + " " + r.z);
                // 向下衝快、向上爬慢
                distanceTravelled += speed * Time.deltaTime;
                // distanceTravelled += speed * (r.z > 0.0f ? (1.0f - r.z) : r.z * (-2.0f) + 1.0f) * Time.deltaTime;
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction) * Quaternion.Euler(0, 0, 90);
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);

                // transform.GetChild(0).localRotation = Quaternion.Euler(transform.GetChild(0).localRotation.x + 90, transform.GetChild(0).localRotation.y, 0);
                // transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, 0);
            }
        }
        
        public void StartRiding()
        {
            PathLen = pathCreator.path.length;
            speed = pathCreator.path.length / 138f;
            pathPlacer.startMove = true;
            pathPlacer.Generate();

            // transform.Find("Model").gameObject.SetActive(true); 
            // spawn notes
            // playerOriginalPostion = player.position;
            // playerOriginalRotation = player.rotation;
            player.position = transform.position + transform.up  * positionUpOffset;
            player.forward = transform.forward;
            player.transform.parent = transform;
            // onTrain = true;
            // trainController.transform.Find("Model").gameObject.SetActive(false);
            // easyMovementController.enableControl = false;
            StartCoroutine(waitBGM());
            // Debug.Log("StartRiding");
        }

        public IEnumerator waitBGM()
        {
            yield return new WaitForSeconds(0.5f);
            isRiding = true;
            // m_AudioSource.Play();
        }
    }
}