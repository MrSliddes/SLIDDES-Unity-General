using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SLIDDES.Components
{
    /// <summary>
    /// A group of gameobjects
    /// </summary>
    [AddComponentMenu("SLIDDES/Components/GameObjects Group")]
    public class GameObjectsGroup : MonoBehaviour
    {
        public List<GameObject> gameObjects = new List<GameObject>();

        private void OnEnable()
        {
            foreach(var item in gameObjects)
            {
                if(item != null) item.SetActive(true);
            }
        }

        private void OnDisable()
        {
            foreach(var item in gameObjects)
            {
                if(item != null) item.SetActive(false);
            }
        }

#if UNITY_EDITOR

        private void OnDrawGizmosSelected()
        {
            foreach(var item in gameObjects)
            {
                if(item == null) continue;
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(item.transform.position, 1);
            }
        }

#endif
    }
}
