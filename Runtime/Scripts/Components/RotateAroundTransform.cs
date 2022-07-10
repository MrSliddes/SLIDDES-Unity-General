using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SLIDDES.Components
{
    /// <summary>
    /// Rotates the transform around another transform (like a moon orbiting a planet)
    /// </summary>
    [AddComponentMenu("SLIDDES/Components/Rotate Around Transform")]
    public class RotateAroundTransform : MonoBehaviour
    {
        [Tooltip("The speed at which to rotate around the center")]
        public float speed = 10;
        [Tooltip("The direction to rotate around the center")]
        public Vector3 rotationDirection;
        [Tooltip("The transform to rotate around")]
        public Transform center;

        // Update is called once per frame
        void Update()
        {
            if(center != null) transform.RotateAround(center.position, rotationDirection, speed * Time.deltaTime);
        }
    }
}
