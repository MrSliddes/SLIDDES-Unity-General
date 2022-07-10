using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace SLIDDES.Components
{
    [AddComponentMenu("SLIDDES/Components/Ininite Background Scroller")]
    public class InfiniteBackgroundScroller : MonoBehaviour
    {
        [Tooltip("The width of each panel")]
        [SerializeField] private float panelWidth = 10;
        [Tooltip("The speed at which the panels move.")]
        public float scrollSpeed = 1;
        [Tooltip("The direction at which the panels move")]
        public Vector3 scrollDirection = new Vector3(-1, 0, 0);

        [Tooltip("The repeating panels")]
        public Transform[] panels;

        /// <summary>
        /// The panel that is the first in line
        /// </summary>
        public int firstInLineIndex;

        // Start is called before the first frame update
        void Start()
        {
            if(panels.Length < 3) Debug.LogError("[InfiniteBackgroundScoller] Panel length is too small! You need atleast 3 panels");
            SetStartPositions();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateBackgroundPanels();
        }

        private void SetStartPositions()
        {
            int increase = -1;
            for(int i = 0; i < panels.Length; i++)
            {
                panels[i].position = new Vector3(transform.position.x + panelWidth * increase, panels[i].position.y, panels[i].position.z);
                increase++;
            }
        }

        private void UpdateBackgroundPanels()
        {
            // Update the first in line panel
            panels[firstInLineIndex].position += scrollDirection * Time.deltaTime * scrollSpeed;
            // If first in line is out of bounds set new first in line
            if(panels[firstInLineIndex].position.x < transform.position.x + scrollDirection.x * panelWidth)
            {
                firstInLineIndex = firstInLineIndex >= panels.Length - 1 ? 0 : firstInLineIndex + 1;
            }

            // Update rest of panels based on first in line position
            for(int i = 0; i < panels.Length; i++)
            {
                if(i == firstInLineIndex) continue;
                int increment = i > firstInLineIndex ? i - firstInLineIndex : (panels.Length - firstInLineIndex) + i;
                panels[i].position = new Vector3(panels[firstInLineIndex].position.x + increment * panelWidth, 0, 0);
            }
        }
    }
}