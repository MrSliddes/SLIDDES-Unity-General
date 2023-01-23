using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SLIDDES
{
    public static class AnimatorExtentions
    {
        /// <summary>
        /// Check if the current animation is finished playing
        /// </summary>
        /// <param name="animator">The animator component to check it from</param>
        /// <param name="layerIndex">The layerIndex of the animator</param>
        /// <returns>True if animation has finished, else false</returns>
        public static bool AnimationIsFinished(this Animator animator, int layerIndex = 0, float normilizedFinishedTime = 1)
        {
            return animator.GetCurrentAnimatorStateInfo(layerIndex).normalizedTime >= normilizedFinishedTime && !animator.IsInTransition(layerIndex);
        }
    }
}
