using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SLIDDES.Interacting
{
    /// <summary>
    /// For handling looking interaction
    /// </summary>
    public interface ILookInteraction
    {
        /// <summary>
        /// When the gameObject first looks at ILookInteraction object
        /// </summary>
        /// <param name="gameObject">The gameobject that is looking</param>
        public void Enter(GameObject gameObject);

        /// <summary>
        /// When the gameObject keeps looking at ILookInteraction object
        /// </summary>
        /// <param name="gameObject">The gameobject that is looking</param>
        public void Stay(GameObject gameObject);

        /// <summary>
        /// When the gameObject stops looking at ILookInteraction object
        /// </summary>
        /// <param name="gameObject">The gameobject that is looking</param>
        public void Exit(GameObject gameObject);

        /// <summary>
        /// Where the raycasthit from LookInteraction hit
        /// </summary>
        /// <param name="hit"></param>
        public virtual void Hit(RaycastHit hit)
        {

        }
    }
}
