﻿using PathCreation;
using UnityEngine;

namespace PathCreation.Examples {

    [ExecuteInEditMode]
    public class PathPlacer_yun : PathSceneTool {

        public GameObject prefab;
        public GameObject holder;
        public float spacing = 3;

        const float minSpacing = .1f;

        public void Generate () {
            if (pathCreator != null && prefab != null && holder != null) {
                DestroyObjects ();

                VertexPath path = pathCreator.path;

                spacing = Mathf.Max(minSpacing, spacing);
                float dst = 0;

                while (dst < path.length) {
                    Vector3 point = path.GetPointAtDistance (dst);
                    Quaternion rot = path.GetRotationAtDistance (dst);
                    // Debug.Log(rot * Vector3.forward);
                    // 向下生成距離長(速度快)、向上生成距離短(速度慢)
                    Instantiate (prefab, point, rot, holder.transform);
                    float yy = (rot * Vector3.forward).y;
                    dst += spacing * (yy > 0 ? (1.0f - yy) : yy * (-2.0f) + 1.0f);
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