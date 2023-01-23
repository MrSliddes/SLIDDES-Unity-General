using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SLIDDES.ScriptableObjects
{
    /// <summary>
    /// For use of the animation curve component in an scriptable object
    /// </summary>
    [CreateAssetMenu(fileName = "Animation Curve SO", menuName = "SLIDDES/Scriptable Objects/Animation Curve")]
    public class AnimationCurveSO : ScriptableObject
    {
        [TextArea(1, 10)]
        public string description;

        public AnimationCurve animationCurve;

        /// <summary>
        /// Get the y-axis value of the curve at the given time (x-axis)
        /// </summary>
        /// <param name="time">The time of the curve to get the value at (x-axis position)</param>
        /// <returns>float of corresponding y-axis value</returns>
        public float Evaluate(float time)
        {
            return animationCurve.Evaluate(time);
        }
    }
}
