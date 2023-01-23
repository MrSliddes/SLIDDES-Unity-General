using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SLIDDES.Presence
{
    /// <summary>
    /// Instance of managing the presence of gameobjects with a PresenceRegistrator script attached
    /// </summary>
    public class PresenceManager : MonoBehaviour
    {
        public static PresenceManager Instance
        {
            get
            {
                if(instance == null)
                {
                    GameObject a = new GameObject("[Presence Manager]");
                    instance = a.AddComponent<PresenceManager>();
                }
                return instance;
            }
        }

        /// <summary>
        /// True if the application is quitting. Prevents creating instance when aplication is quitting
        /// </summary>
        private bool applicationQuitting;
        /// <summary>
        /// A dictionary containing all registerd gameobjects. key = tag of gameobject
        /// </summary>
        private Dictionary<string, List<GameObject>> presentGameObjects = new Dictionary<string, List<GameObject>>();
        /// <summary>
        /// Instance reference
        /// </summary>
        private static PresenceManager instance;

        private void OnEnable()
        {
            Application.quitting += () => applicationQuitting = true;
        }

        private void OnDisable()
        {
            Application.quitting -= () => applicationQuitting = true;
        }

        private void OnDestroy()
        {
            Application.quitting -= () => applicationQuitting = true;
        }

        private void Awake()
        {
            if(instance != null && instance != this)
            {
                Debug.LogError("[PresenceManager] More than 1 instance of presenceManager is active! Make sure there is only 1 instance of this in your scene. Disabling script...");
                enabled = false;
                return;
            }
            instance = this;

            presentGameObjects.Clear();
        }

        public static Type[] GetComponents<Type>(string gameObjectTag) where Type : Component
        {
            // Check if tag is present
            if(Instance.presentGameObjects.ContainsKey(gameObjectTag))
            {
                // Key is present, return components
                Type[] types = new Type[Instance.presentGameObjects[gameObjectTag].Count];
                for(int i = 0; i < Instance.presentGameObjects[gameObjectTag].Count; i++)
                {
                    types[i] = Instance.presentGameObjects[gameObjectTag][i].GetComponent<Type>();
                }
                return types;
            }
            // Key was not present
            return null;
        }

        /// <summary>
        /// Get gameObjects with the tag
        /// </summary>
        /// <param name="gameObjectTag">The tag the gameObjects should have</param>
        /// <returns>GameObject[]. If nothing is found it returns null</returns>
        public static GameObject[] GetGameObjects(string gameObjectTag)
        {
            // Check if tag is present
            if(Instance.presentGameObjects.ContainsKey(gameObjectTag))
            {
                // Key is present, return gameobjects
                return Instance.presentGameObjects[gameObjectTag].ToArray();
            }
            // Key was not present
            return null;
        }

        /// <summary>
        /// Add a gameObject to the presentGameObjects Dictionary
        /// </summary>
        /// <param name="gameObject">The gameObject to register</param>
        public static void Register(GameObject gameObject)
        {
            // Check if gameObject tag is present
            if(Instance.presentGameObjects.ContainsKey(gameObject.tag))
            {
                // Tag is present, add gameobject to the list
                Instance.presentGameObjects[gameObject.tag].Add(gameObject);
            }
            else
            {
                // Tag is not present, create it
                Instance.presentGameObjects.Add(gameObject.tag, new List<GameObject>() { gameObject });
            }
        }

        /// <summary>
        /// Register a gameobject
        /// </summary>
        /// <param name="gameObject">The gameObject to unregister</param>
        public static void UnRegister(GameObject gameObject)
        {
            // Check if game is not exiting
            if(instance == null || instance.applicationQuitting) return;

            // Check if gameObject tag is present
            if(Instance.presentGameObjects.ContainsKey(gameObject.tag) )
            {
                if(Instance.presentGameObjects[gameObject.tag].Contains(gameObject))
                {
                    // Remove the gameobject from the list
                    Instance.presentGameObjects[gameObject.tag].Remove(gameObject);
                    // If no gameobjects are left remove tag key from dictionary
                    if(Instance.presentGameObjects[gameObject.tag].Count <= 0)
                    {
                        Instance.presentGameObjects.Remove(gameObject.tag);
                    }
                }
            }
            // tag was not present, dont need to unregister
        }
    }
}
