using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SLIDDES.Components
{
    /// <summary>
    /// Class for basic animation clip event script callbacks
    /// </summary>
    [AddComponentMenu("SLIDDES/Components/Animation Event Callback")]
    public class AnimationEventCallback : MonoBehaviour
    {
        public Events events = new Events();

        public void OnAnimationStart()
        {
            events?.onAnimationStart.Invoke();
        }

        public void OnAnimationEnd()
        {
            events?.onAnimationEnd.Invoke();
        }

        public void OnAnimationFloat(float value)
        {
            events?.onAnimationFloat.Invoke(value);
        }

        [System.Serializable]
        public class Events
        { 
            public UnityEvent onAnimationStart;
            public UnityEvent onAnimationEnd;
            public UnityEvent<float> onAnimationFloat;        
        }
    }
}
