using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace SLIDDES.Interacting
{
    public interface IInteraction
    {
        /// <summary>
        /// The input that was used for this interaction
        /// </summary>
        /// <param name="context">The callback context. Cann be null cause of the ? in the parameter</param>
        public virtual void Input(InputAction.CallbackContext? context)
        {

        }

        /// <summary>
        /// When the interaction first gets enterd
        /// </summary>
        /// <param name="gameObject">The gameObject that wants to interact</param>
        public virtual void Enter(GameObject gameObject)
        {

        }

        /// <summary>
        /// Interact with the gameobject
        /// </summary>
        /// <param name="gameObject">The gameObject that wants to interact</param>        
        public virtual void Update(GameObject gameObject)
        {

        }

        /// <summary>
        /// Exit an interaction
        /// </summary>
        /// <param name="gameObject">The gameobject that wants to exit the interaction</param>
        public virtual void Exit(GameObject gameObject)
        {

        }
    }
}