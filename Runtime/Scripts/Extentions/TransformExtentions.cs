using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SLIDDES
{
    public static class TransformExtentions
    {
        /// <summary>
        /// Get the most upper parent in the hierarcy from a transform
        /// </summary>
        /// <param name="transform"></param>
        /// <returns></returns>
        public static Transform GetFirstParent(this Transform transform)
        {
            Transform t = transform;
            if(transform.parent != null)
            {
                t = GetFirstParent(transform.parent);
            } 
            
            return t;
        }

        /// <summary>
        /// Get a transform inside a transform that has the given name
        /// </summary>
        /// <param name="transform">The transform to search through</param>
        /// <param name="name">The name the transform should have</param>
        /// <param name="recursive">Also search in each child transforms</param>
        /// <param name="caseSensitive">Is the name case sensitive?</param>
        /// <returns>Transform or null if no match has been found</returns>
        public static Transform TransformFromString(this Transform transform, string name, bool recursive = true, bool caseSensitive = false)
        {
            if(!caseSensitive) name = name.ToLower();
            foreach(Transform item in transform)
            {
                string s = caseSensitive ? item.name : item.name.ToLower();
                if(s.Contains(name))
                {
                    return item;
                }

                if(recursive)
                {
                    Transform child = item.TransformFromString(name, recursive, caseSensitive);
                    if(child != null) return child;
                }
            }
            return null;
        }

        /// <summary>
        /// Set the layer & the children layers
        /// </summary>
        /// <param name="transform">The transform to set the layer</param>
        /// <param name="layer">The new layer of the transform & its children</param>
        public static void SetLayerRecursively(this Transform transform, int layer)
        {
            transform.gameObject.layer = layer;
            foreach(Transform child in transform)
            {
                child.SetLayerRecursively(layer);
            }
        }
    }
}
