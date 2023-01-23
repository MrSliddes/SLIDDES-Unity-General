using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SLIDDES.Components.Editor
{
    [CustomEditor(typeof(UnityEventsInvoker))]
    public class UnityEventsInvokerEditor : UnityEditor.Editor
    {
        private UnityEventsInvoker selected;

        private void OnEnable()
        {
            selected = (UnityEventsInvoker)target;
        }

        public override void OnInspectorGUI()
        {
            if(selected.unityEvents != null)
            {
                for(int i = 0; i < selected.unityEvents.Count; i++)
                {
                    if(GUILayout.Button($"Invoke Event {i}"))
                    {
                        selected.unityEvents[i].Invoke();
                    }
                }
            }

            string t = selected.isToggled ? "Off" : "On";
            if(GUILayout.Button($"Toggle {t}"))
            {
                selected.isToggled = !selected.isToggled;
                selected.onCallbackToggle.Invoke(selected.isToggled);
            }

            base.OnInspectorGUI();
        }
    }
}
