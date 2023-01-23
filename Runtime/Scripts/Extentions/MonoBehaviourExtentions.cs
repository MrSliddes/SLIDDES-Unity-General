using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SLIDDES
{
    /// <summary>
    /// Extention class for monobehaviour
    /// </summary>
    public static class MonoBehaviourExtentions
    {
        /// <summary>
        /// For easily waiting before executing a method
        /// </summary>
        /// <example>
        /// this.Wait(5, MethodName);
        /// </example>
        /// <param name="monoBehaviour">The monobehaviour the coroutine belongs to</param>
        /// <param name="delay">The time to wait for in seconds</param>
        /// <param name="unityAction">Action to invoke after waiting</param>
        /// <returns>Coroutine</returns>
        public static Coroutine Wait(this MonoBehaviour monoBehaviour, float delay, UnityAction unityAction)
        {
            return monoBehaviour.StartCoroutine(ExecuteAction(delay, unityAction));
        }

        /// <summary>
        /// Execute the unityAction after waiting for delay
        /// </summary>
        /// <param name="delay"></param>
        /// <param name="unityAction"></param>
        /// <returns></returns>
        private static IEnumerator ExecuteAction(float delay, UnityAction unityAction)
        {
            yield return new WaitForSeconds(delay);
            unityAction?.Invoke();
            yield break;
        }
    }
}
