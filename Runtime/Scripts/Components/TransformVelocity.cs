using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SLIDDES.Components
{
    /// <summary>
    /// Get the velocity of an transform
    /// </summary>
    [AddComponentMenu("SLIDDES/Components/Transform Velocity")]
    public class TransformVelocity : MonoBehaviour
    {
        public Vector3 Velocity { get; private set; }

        private Vector3 previousPosition;

        // Update is called once per frame
        void Update()
        {
            Velocity = (transform.position - previousPosition).normalized;
            previousPosition= transform.position;
        }
    }
}
