using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SLIDDES.Components
{
    /// <summary>
    /// Quickly use the gizmos for debugging purposes
    /// </summary>
    public class GizmosDebugger : MonoBehaviour
    {
        public static GizmosDebugger Instance
        {
            get
            {
                if(instance == null)
                {
                    GameObject a = new GameObject("[GizmosDebugger]");
                    instance = a.AddComponent<GizmosDebugger>();
                }
                return instance;
            }
        }

        private static GizmosDebugger instance;

        private List<RaycastDraw> raycastDraws = new List<RaycastDraw>();
        private List<PointDraw> pointDraws = new List<PointDraw>();

        private void Awake()
        {
            if(instance != null && instance != this)
            {
                Debug.LogWarning("[GizmosDebugger] Only 1 instance of this script is allowed! Disabling script...");
                enabled = false;
            }
            instance = this;
        }

        public static void DrawPoint(Vector3 position, float radius, Color color, float lifeTime = -8)
        {
            if(!Application.isEditor) return;

            Instance.pointDraws.Add(new PointDraw()
            {
                position = position,
                radius = radius,
                color = color,
                lifeTime = lifeTime
            });
        }

        public static void DrawRaycast(Vector3 start, Vector3 end, Color color, float lifeTime = -8)
        {
            if(!Application.isEditor) return;

            Instance.raycastDraws.Add(new RaycastDraw()
            {
                start = start,
                end = end,
                color = color,
                lifeTime = lifeTime
            });
        }


        private void OnDrawGizmos()
        {
            // Raycasts
            for(int i = raycastDraws.Count - 1; i >= 0 ; i--)
            {
                RaycastDraw item = raycastDraws[i];
                Gizmos.color = item.color;
                Gizmos.DrawLine(item.start, item.end);
                if(item.lifeTime != -8)
                {
                    item.lifeTime -= Time.deltaTime;
                    if(item.lifeTime <= 0)
                    {
                        raycastDraws.Remove(item);
                    }
                }
            }

            // Points
            for(int i = pointDraws.Count - 1; i >= 0; i--)
            {
                PointDraw item = pointDraws[i];
                Gizmos.color = item.color;
                Gizmos.DrawWireSphere(item.position, item.radius);
                if(item.lifeTime != -8)
                {
                    item.lifeTime -= Time.deltaTime;
                    if(item.lifeTime <= 0)
                    {
                        pointDraws.Remove(item);
                    }
                }
            }
        }


        private class RaycastDraw
        {
            public Vector3 start;
            public Vector3 end;
            public Color color;
            public float lifeTime;
        }

        private class PointDraw
        {
            public Vector3 position;
            public float radius;
            public Color color;
            public float lifeTime;
        }
    }
}
