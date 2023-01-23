using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SLIDDES.Interacting
{
    /// <summary>
    /// For interacting with objects
    /// </summary>
    [AddComponentMenu("SLIDDES/Interact")]
    public class Interact : MonoBehaviour
    {
        public bool IsInteracting => currentInteraction != null;
        public bool IsLookInteracting => currentLookInteraction != null;

        [Header("Values")]
        [Tooltip("Show component debug logs")]
        public bool debug;
        [Tooltip("update the look interaction in MonoBehaviour.Update")]
        public bool onUpdateLookInteraction = true;
        [Tooltip("The max interacting distance in meters")]
        public int maxInteractingDistance = 3;
        [Tooltip("The layermask of the interacting raycast")]
        public LayerMask layerMaskInteraction;

        [Header("Components")]
        public new Camera camera;
        [Tooltip("The gameobject that is interacting with interactables (example the player gameobject)")]
        public GameObject interactingGameObject;
        [Tooltip("The collider to toggle off when raycasting")]
        public Collider[] collidersToToggle;

        /// <summary>
        /// Raycast hit used for raycast
        /// </summary>
        private RaycastHit hit;
        /// <summary>
        /// Raycasthit for lookinteraction
        /// </summary>
        private RaycastHit lookHit;
        /// <summary>
        /// The current IInteraction for this script
        /// </summary>
        private IInteraction currentInteraction;
        /// <summary>
        /// The current ILookInteraction for this script
        /// </summary>
        private ILookInteraction currentLookInteraction;

        public void Update()
        {
            if(onUpdateLookInteraction) CheckLookInteraction();
        }

        /// <summary>
        /// Check for an interaction with raycast
        /// </summary>
        /// <param name="interact">Actually interact with the interaction</param>
        public void CheckInteraction(InputAction.CallbackContext? context = null)
        {
            // Shoot raycast center of screen
            CollidersToggle(false);
            if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, maxInteractingDistance, layerMaskInteraction))
            {
                CollidersToggle(true);
                IInteraction interaction = hit.transform.GetComponent<IInteraction>();
                if(interaction != null)
                {
                    // We have an interaction, check if we already have an interaction with the same one or if it is a new one
                    if(currentInteraction == null)
                    {
                        // New interaction
                        if(debug) Debug.Log("[Interact] Interaction with " + hit.transform.name);
                        currentInteraction = interaction;
                        currentInteraction.Input(context);
                        currentInteraction.Enter(interactingGameObject);
                        return;
                    }
                    else if(currentInteraction == interaction)
                    {
                        // Existing interaction
                        currentInteraction.Input(context);
                        currentInteraction.Update(interactingGameObject);
                    }
                    else if(currentInteraction != interaction)
                    {
                        // New interaction but already had interaction
                        currentInteraction.Input(context);
                        currentInteraction.Exit(interactingGameObject);
                        currentInteraction = interaction;
                        currentInteraction.Input(context);
                        currentInteraction.Enter(interactingGameObject);
                        return;
                    }
                    return;
                }
            }
            CollidersToggle(true);

            // Exit
            ExitLookInteraction(context);
            ExitInteraction(context);
        }

        /// <summary>
        /// Check for look interaction with raycast
        /// </summary>
        public void CheckLookInteraction()
        {
            // Shoot raycast center of screen
            CollidersToggle(false);
            if(Physics.Raycast(camera.transform.position, camera.transform.forward, out lookHit, maxInteractingDistance, layerMaskInteraction))
            {
                CollidersToggle(true);
                if(debug) Debug.Log(lookHit.transform.name);
                ILookInteraction lookInteraction = lookHit.transform.GetComponent<ILookInteraction>();
                if(lookInteraction != null)
                {
                    // We have an interaction, check if we already have an interaction with the same one or if it is a new one
                    if(currentLookInteraction == null)
                    {
                        // New look interaction
                        if(debug) Debug.Log("[Interact] Look interaction with " + lookHit.transform.name);
                        currentLookInteraction = lookInteraction;
                        currentLookInteraction.Hit(lookHit);
                        currentLookInteraction.Enter(interactingGameObject);
                        return;
                    }
                    else if(currentLookInteraction == lookInteraction)
                    {
                        // Existing interaction
                        currentLookInteraction.Hit(lookHit);
                        currentLookInteraction.Stay(interactingGameObject);
                    }
                    else if(currentLookInteraction != lookInteraction)
                    {
                        // New look interaction but already had look interaction
                        currentLookInteraction.Hit(lookHit);
                        currentLookInteraction.Exit(interactingGameObject);
                        currentLookInteraction = lookInteraction;
                        currentLookInteraction.Hit(lookHit);
                        currentLookInteraction.Enter(interactingGameObject);
                        return;
                    }
                    return;
                }
            }
            CollidersToggle(true);

            // Exit
            ExitLookInteraction();
        }

        #region Input

        /// <summary>
        /// Interact when inputaction button is pressed. Called from outside this script
        /// </summary>
        /// <param name="context"></param>
        public void InputCheckInteraction(InputAction.CallbackContext context)
        {
            if(debug) Debug.Log("[Interact] Interaction triggerd by: " + context.control.device.displayName);
            //if(context.action.triggered || context.control.device.displayName == "Mouse")
            if(context.action.triggered)
            {
                CheckInteraction(context);
            }
            else if(context.ReadValue<float>() <= 0)
            {
                // Let go of button
                ExitInteraction();
                ExitLookInteraction(context);
            }
        }

        public void InputCheckLookInteraction(InputAction.CallbackContext context)
        {
            CheckLookInteraction();
        }

        #endregion

        private void ExitInteraction(InputAction.CallbackContext? context = null)
        {
            if(currentInteraction != null)
            {
                if(debug) Debug.Log("[Interact] Exit interaction");
                currentInteraction.Exit(interactingGameObject);
                currentInteraction = null;
            }
        }

        private void ExitLookInteraction(InputAction.CallbackContext? context = null)
        {
            if(currentLookInteraction != null)
            {
                if(debug) Debug.Log("[Interact] Exit look interaction");
                if(currentInteraction != null) currentInteraction.Input(context);
                currentLookInteraction.Exit(interactingGameObject);
                currentLookInteraction = null;
            }
        }

        private void CollidersToggle(bool enabled)
        {
            for(int i = 0; i < collidersToToggle.Length; i++)
            {
                collidersToToggle[i].enabled = enabled;
            }
        }

#if UNITY_EDITOR

        private void OnDrawGizmosSelected()
        {
            if(!debug) return;
            // Draw interaction line
            Gizmos.color = Color.red;
            if(camera != null) Gizmos.DrawLine(camera.transform.position, lookHit.point);
        }

#endif
    }
}