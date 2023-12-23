using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Utility;

namespace PathCreation.Examples {
    public class NoteSpawn : MonoBehaviour
    {
        public GameObject PathPointsHolder;
        // public GameObject _roadMeshCreator;
        public RoadMeshCreator roadMeshCreator;
        public PathPlacer_yun _pathPlacer;
        // public PathPlacer _pathPlacer;
        [SerializeField] GameObject[] Note = new GameObject[7];
        [SerializeField] Material[] Mat = new Material[4];
        private GameObject playerCamera;
        private float[] trails;
        private float[] beatPos = new float[2];
        private bool show = false;
        public int trailNum = 4;
        public int NoteID;
        public int score;
        private int[] noteScores = { 2, 1, 2, 3, 6, 9, 12 };
        private GameObject clone;
        // Start is called before the first frame update
        void Start()
        {
            // roadMeshCreator = _roadMeshCreator.GetComponent<RoadMeshCreator>();
            trails = new float[trailNum];
            float trailWidth = roadMeshCreator.roadWidth * 2 / trailNum;
            float _start = (trailWidth - roadMeshCreator.roadWidth * 2) / 2.0f;
            for(int i = 0; i < trailNum; i++){
                trails[i] = _start + trailWidth * i;
            }
            playerCamera = GameObject.Find("OVRCameraRig");
            show = false;
            if( NoteID == 7 ) NoteID = 1;
            else if ( NoteID > 7 ) return;
            score = noteScores[NoteID];
            clone = Instantiate(Note[NoteID], new Vector3(0, 0, 0), Quaternion.identity, this.transform); //new Quaternion(0.0f,-0.70710682f,0f,0.707106829f));
            clone.transform.localPosition = new Vector3(-0.2f, trails[Random.Range(0, trailNum)], 0.0f);
            clone.transform.localRotation = clone.transform.localRotation  * Quaternion.Euler(90, 0, 90);
            if ( NoteID != 1 ) clone.transform.localScale = clone.transform.localScale * 2;
            // clone.transform.localPosition = new Vector3(trails[Random.Range(0, trailNum)], 0.2f, 0.0f);
            clone.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = NoteID == 1 ? Mat[0] : Mat[1];
            clone.transform.GetChild(0).gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if(NoteID == 7) return;
            if(Vector3.Distance(playerCamera.transform.position, transform.position) < 5 && !show){
                show = true;
                clone.transform.GetChild(0).gameObject.SetActive(true);
                // clone.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = Mat[Random.Range(0, 4)];
            } 
            // else if (Vector3.Distance(playerCamera.transform.position, transform.position) > 100 && show){
            //     Object.Destroy(this.transform.GetChild(0).gameObject);
            //     show = false;
            // }
            // Debug.Log(Vector3.Distance(playerCamera.transform.position, transform.position));
            
        }
    }
}