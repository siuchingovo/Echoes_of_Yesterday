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
        // Start is called before the first frame update
        void Start()
        {
            isRiding = false;
            distanceTravelled = 0f;
            StartRiding();
            speed = pathCreator.path.length / 28f;
            // len = pathCreator.path.length;
            // Debug.Log(pathCreator.path.length);
        }

        // Update is called once per frame
        void Update()
        {
            if (pathCreator != null && isRiding)
            {
                Quaternion r = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                // Debug.Log(r.x + " " + r.y + " " + r.z);
                // 向下衝快、向上爬慢
                distanceTravelled += speed * Time.deltaTime;
                // distanceTravelled += speed * (r.z > 0.0f ? (1.0f - r.z) : r.z * (-2.0f) + 1.0f) * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction) * Quaternion.Euler(90, 0, 90);
            }
        }
        
        public void StartRiding()
        {
            isRiding = true;
            transform.Find("Model").gameObject.SetActive(true); 
            // spawn notes
            Debug.Log("StartRiding");
            pathPlacer.Generate();
        }
    }
}