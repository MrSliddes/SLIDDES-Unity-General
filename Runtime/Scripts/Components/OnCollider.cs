using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SLIDDES.Components
{

    /// <summary>
    /// Generic class for collider functions
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    [AddComponentMenu("SLIDDES/Components/OnCollider")]
    public class OnCollider : MonoBehaviour
    {
        [Tooltip("Should the collider reset any collisions that come in contact to another position?")]
        public bool repositionOnContact;
        [Tooltip("The reposition position")]
        public Transform repositionTransform;


        private void Reposition(Transform target)
        {
            target.position = repositionTransform.position;
        }


        private void OnCollisionEnter(Collision collision)
        {
            if(repositionOnContact) { Reposition(collision.transform); }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(repositionOnContact) { Reposition(other.transform); }
        }
    }
}
