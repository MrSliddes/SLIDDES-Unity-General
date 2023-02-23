using System;
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
        /// <param name="invoker">The gameObject that wants to interact</param>
        public virtual void Enter(GameObject invoker)
        {

        }

        /// <summary>
        /// Interact with the gameobject
        /// </summary>
        /// <param name="invoker">The gameObject that wants to interact</param>        
        public virtual void Update(GameObject invoker)
        {

        }

        /// <summary>
        /// Exit an interaction
        /// </summary>
        /// <param name="invoker">The gameobject that wants to exit the interaction</param>
        public virtual void Exit(GameObject invoker)
        {

        }

        /// <summary>
        /// Get the gameobject coupled to the interaction
        /// </summary>
        /// <param name="invoker">The gameobject that wants to get the other gameobject</param>
        public virtual GameObject GameObject(GameObject invoker = null)
        {
            throw new NotImplementedException();
        }
    }
}