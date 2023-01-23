using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SLIDDES.Components
{
    [AddComponentMenu("SLIDDES/Components/Unity Events Invoker")]
    [Tooltip("For easy event invoking in Unity editor")]
    public class UnityEventsInvoker : MonoBehaviour
    {
        [Header("Events")]
        public UnityEvent<bool> onCallbackToggle;
        public List<UnityEvent> unityEvents = new List<UnityEvent>();

        [HideInInspector] public bool isToggled;
    }
}
