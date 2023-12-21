using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

namespace PathCreation.Examples {
    public class MRTrainController : MonoBehaviour
    {
        public bool isRiding;
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float distanceTravelled;
        public float speed;
        public PathPlacer pathPlacer;
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
                Quaternion r = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                // Debug.Log(r.x + " " + r.y + " " + r.z);
                // 向下衝快、向上爬慢
                // distanceTravelled += speed * (r.z > 0.0f ? (1.0f - r.z) : r.z * (-2.0f) + 1.0f) * Time.deltaTime;
                distanceTravelled += speed * (r.z > 0.0f ? r.z * (1.5f) + 1.0f : (1.0f + r.z)) * Time.deltaTime;

                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
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