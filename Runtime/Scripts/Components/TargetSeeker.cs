using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SLIDDES.Components
{
    /// <summary>
    /// Seeks for a target
    /// </summary>
    [AddComponentMenu("SLIDDES/Components/Target Seeker")]
    public class TargetSeeker : MonoBehaviour
    {
        /// <summary>
        /// The direction of the seeker relative to the target
        /// </summary>
        public Vector3 NormalizedDirection
        { 
            get
            {
                if(target == null) return Vector3.zero;
                return (target.position - transform.position).normalized;
            }
        }
        /// <summary>
        /// Velocity of the TS
        /// </summary>
        public float Velocity
        {
            get
            {
                return velocity;
            }
        }
        /// <summary>
        /// The location of the TS last frame
        /// </summary>
        public Vector3 LastFrameLocation { get; private set; }

        [Header("Values")]
        [Tooltip("The tag of the target")]
        public string targetTag = "Player";
        [Tooltip("Check every x seconds if the target is still the closest target")]
        public float targetRefreshTime = 2;
        [Tooltip("The transform of the target")]
        public Transform target;

        [Header("Events")]
        [Tooltip("Called when the target gets changed")]
        public UnityEvent<Transform> onTargetChange;

        /// <summary>
        /// A array of all targets found
        /// </summary>
        [HideInInspector] public Transform[] foundTargets;
        /// <summary>
        /// The velocity of the target seeker
        /// </summary>
        private float velocity;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(FindClosestTargetAsync());
        }

        private void Update()
        {
            velocity = (transform.position - LastFrameLocation).magnitude / Time.deltaTime;
            LastFrameLocation = transform.position;
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
            onTargetChange?.Invoke(this.target);
        }

        protected virtual Transform[] GetTargets()
        {
            var g = GameObject.FindGameObjectsWithTag(targetTag); // expensive, find alternative; 
            var t = new Transform[g.Length];
            for(int i = 0; i < g.Length; i++)
            {
                t[i] = g[i].transform;
            }
            return t;
        }

        /// <summary>
        /// Finds the closest target
        /// </summary>
        /// <returns>nothing</returns>
        private IEnumerator FindClosestTargetAsync()
        {
            while(true)
            {
                // Get the targets
                foundTargets = GetTargets();

                // If no targets
                if(foundTargets == null || foundTargets.Length == 0)
                {
                    if(target != null)
                    {
                        SetTarget(null);
                    }
                }
                else
                {
                    // Got targets, check which one is the closest
                    float closestDistance = Vector3.Distance(transform.position, foundTargets[0].transform.position);
                    int closestTargetIndex = 0;
                    for(int i = 1; i < foundTargets.Length; i++)
                    {
                        float distance = Vector3.Distance(transform.position, foundTargets[i].transform.position);
                        if(distance < closestDistance)
                        {
                            // New closer target
                            closestTargetIndex = i;
                            closestDistance = distance;
                        }
                    }

                    // Set new target
                    if(target != foundTargets[closestTargetIndex].transform)
                    {
                        SetTarget(foundTargets[closestTargetIndex].transform);
                    }
                }                

                // Await
                yield return new WaitForSeconds(targetRefreshTime);
            }
        }

#if UNITY_EDITOR

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + NormalizedDirection * 1);
        }

#endif
    }
}
