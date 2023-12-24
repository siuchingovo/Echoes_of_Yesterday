﻿using PathCreation;
using UnityEngine;

namespace PathCreation.Examples {

    [ExecuteInEditMode]
    public class PathPlacer_yun : PathSceneTool {

        public GameObject prefab;
        public GameObject holder;
        public float spacing = 3;

        public bool startMove = false;
        public int TotalScore = 0;

        const float minSpacing = .1f;
        // public int idx = 0;
        // public int localCount = 0;

        // public int[] noteNumber = { 48, 57, 59, 60, };
        private int[] noteType = { 4, 7, 2, 0, 5, 2, 0, 4, 4, 4, 
                                   3, 3, 4, 7, 7, 4, 7, 2, 0, 5, 
                                   2, 0, 5, 3, 4, 3, 3, 4, 4, 4, 
                                   7, 3, 5, 3, 5, 3, 5, 3, 4, 4, 
                                   4, 4, 4, 4, 4, 3, 3, 6 };     // 48
        private int[] noteSpace = { 1, 1, 2, 3, 6, 9, 12, 3 };  // 8

        public void Generate () {
            if (pathCreator != null && prefab != null && holder != null) {
                DestroyObjects ();
                if(!startMove) return;
                VertexPath path = pathCreator.path;

                // spacing = 0.9563711f;
                spacing = pathCreator.path.length / 138f / 2;
                // spacing = Mathf.Max(minSpacing, spacing);
                float dst = 0;
                int count = 0;
                int idx = 0;
                int localCount = 0;
                while (dst < path.length) {
                    if(count < 12) {}
                    else if(count < 48 && idx < 48){
                        Vector3 point = path.GetPointAtDistance (dst);
                        Quaternion rot = path.GetRotationAtDistance (dst);
                        // Debug.Log(rot * Vector3.forward);
                        // 向下生成距離長(速度快)、向上生成距離短(速度慢)
                        GameObject clone = Instantiate(prefab, point, rot, holder.transform);
                        clone.GetComponent<NoteSpawn>().NoteID = 1;
                        // float yy = (rot * Vector3.forward).y;
                    } else if(count < 276 && idx < 48){
                        Vector3 point = path.GetPointAtDistance (dst);
                        Quaternion rot = path.GetRotationAtDistance (dst);
                        GameObject clone = Instantiate(prefab, point, rot, holder.transform);

                        if(localCount == 0){
                            clone.GetComponent<NoteSpawn>().NoteID = noteType[idx];
                            Debug.Log(noteType[idx]);
                            localCount++;
                        } else if(localCount == noteSpace[noteType[idx]]){
                            idx++;
                            clone.GetComponent<NoteSpawn>().NoteID = noteType[idx];
                            localCount = 1;
                        } else {
                            clone.GetComponent<NoteSpawn>().NoteID = 1;
                            localCount++;
                        }
                    }
                    count++;
                    dst += spacing;
                    // dst += spacing * (yy > 0 ? (1.0f - yy) : yy * (-2.0f) + 1.0f);
                }
            }
        }

        void DestroyObjects () {
            int numChildren = holder.transform.childCount;
            for (int i = numChildren - 1; i >= 0; i--) {
                DestroyImmediate (holder.transform.GetChild (i).gameObject, false);
            }
        }

        protected override void PathUpdated () {
            if (pathCreator != null) {
                Generate ();
            }
        }
    }
}