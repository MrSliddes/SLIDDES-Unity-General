using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SLIDDES.Presence
{
    /// <summary>
    /// To check if an object is in this area
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    [AddComponentMenu("SLIDDES/Presence/Area Presence")]
    public class AreaPresence : MonoBehaviour
    {
        [Header("Values")]
        [Tooltip("The tag of the gameobjects that can have a presence here")]
        public string targetTag = "Player";

        [Tooltip("Show debug log of script")]
        public bool debug;
        [Tooltip("Show the bounds of the area")]
        public bool debugBounds;

        [Header("Events")]
        [Tooltip("When a target becomes present")]
        public UnityEvent<GameObject> onTargetPresent;
        [Tooltip("When a target becomes absent")]
        public UnityEvent<GameObject> onTargetAbsent;
        [Tooltip("When target enters the area and there are no other targets in the area")]
        public UnityEvent onTargetsPresent;
        [Tooltip("When the last target leaves the area")]
        public UnityEvent onTargetsAbsent;

        private static bool gizmosDrawCubes;
        /// <summary>
        /// The targets in this area
        /// 
        /// <int> (collidersHit)
        /// How many colliders the target has hit of this area (for use in multiple colliders under 1 area script).
        /// With 1 collider the count will never be greater then 1
        /// With 2 colliders it will reach a max of 2 when the colliders are overlapping. As long as the hit count isnt 1 the target will not be removed
        /// </int>
        /// </summary>
        private Dictionary<GameObject, int> targets = new Dictionary<GameObject, int>();

        private void OnEnable()
        {
            targets.Clear();
            onTargetsAbsent?.Invoke();
        }

        private void AddTarget(GameObject target)
        {
            // Check if target is already in here
            if(targets.ContainsKey(target))
            {
                targets[target]++;
                if(debug) Debug.Log("[AreaPresence] Target already present, increase index");
            }
            else
            {
                targets.Add(target, 1);
                if(targets.Count == 1) onTargetsPresent?.Invoke();
                if(debug) Debug.Log("[AreaPresence] Added target");
            }

            onTargetPresent.Invoke(target);
        }

        private void RemoveTarget(GameObject target)
        {
            if(!targets.ContainsKey(target))
            {
                if(debug) Debug.Log("[AreaPresence] Removed a target that was not added...");
                return;
            }

            // Check if target has hit only 1 collider
            if(targets[target] > 1)
            {
                targets[target]--;
                if(debug) Debug.Log("[AreaPresence] Target still in other collider, decrease index");
            }
            else
            {
                targets.Remove(target);
                if(targets.Count <= 0) onTargetsAbsent?.Invoke();
                if(debug) Debug.Log("[AreaPresence] Removed target");
            }

            onTargetAbsent.Invoke(target);
        }


        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag(targetTag)) 
            {
                AddTarget(other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.CompareTag(targetTag))
            {
                RemoveTarget(other.gameObject);
            }
        }

        private void OnDrawGizmos()
        {
            if(gizmosDrawCubes)
            {
                var boxes = GetComponentsInChildren<BoxCollider>();
                foreach(var item in boxes)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawCube(item.transform.TransformPoint(item.center), item.size);
                }
            }
        }

        private void OnValidate()
        {
            gizmosDrawCubes = debugBounds;
        }
    }
}
