using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SLIDDES.Components
{
    /// <summary>
    /// Limit a transform position
    /// </summary>
    [AddComponentMenu("SLIDDES/Components/LimitTransform")]
    public class LimitTransform : MonoBehaviour
    {
        public Space space;

        public Vector3 minimum;
        public Vector3 maximum;

        public UpdateMethod updateMethod;

        private Vector3 boxPos;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if(updateMethod == UpdateMethod.update) Bounds();
        }

        private void LateUpdate()
        {
            if(updateMethod == UpdateMethod.lateUpdate) Bounds();
        }

        private void Bounds()
        {
            Vector3 pos;
            pos = space == Space.world ? transform.position : transform.localPosition;

            // Clamp
            pos.x = Mathf.Clamp(pos.x, minimum.x, maximum.x);
            pos.y = Mathf.Clamp(pos.y, minimum.y, maximum.y);
            pos.z = Mathf.Clamp(pos.z, minimum.z, maximum.z);
            boxPos = pos;

            if(space == Space.world)
            {
                transform.position = pos;
            }
            else
            {
                transform.localPosition = pos;
            }
        }

#if UNITY_EDITOR

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, boxPos);
            //if(space == Space.world)
            //{
            //    Gizmos.DrawWireCube(maximum - minimum, maximum - minimum);
            //}
            //else
            //{
            //    Gizmos.DrawWireCube(transform.parent.position, maximum - minimum);
            //}
        }

#endif

        public enum Space
        {
            world,
            local
        }

        public enum UpdateMethod
        {
            update,
            lateUpdate
        }
    }
}
