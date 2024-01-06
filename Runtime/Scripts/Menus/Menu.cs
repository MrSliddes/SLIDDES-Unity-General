using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SLIDDES.Menus
{
    [AddComponentMenu("SLIDDES/Menus/Menu")]
    public class Menu : MonoBehaviour
    {
        /// <summary>
        /// Close the menu on start
        /// </summary>
        public bool CloseOnStart => closeOnStart;
        /// <summary>
        /// Is the menu closed?
        /// </summary>
        public bool IsClosed => isClosed;

        [Tooltip("Close this menu on start")]
        [SerializeField] private bool closeOnStart;
        [Tooltip("When this menu gets opend all children are set active and vice versa")]
        [SerializeField] private bool toggleChildren;

        [Tooltip("Triggerd when the menu opens")]
        public UnityEvent onOpen;
        [Tooltip("Triggerd when the menu closes")]
        public UnityEvent onClose;
        [Tooltip("Triggerd when the menu opens/closes. bool = isClosed")]
        public UnityEvent<bool> onToggle;

        /// <summary>
        /// Is the menu closed
        /// </summary>
        private bool isClosed;

        // Start is called before the first frame update
        void Start()
        {
            if(closeOnStart)
            {
                Close();
            }
        }

        /// <summary>
        /// Close the menu
        /// </summary>
        public void Close()
        {
            isClosed = true;
            if(toggleChildren) ToggleChildren();
            onClose?.Invoke();
            onToggle?.Invoke(false);
        }

        /// <summary>
        /// Open the menu
        /// </summary>
        public void Open()
        {
            isClosed = false;
            if(toggleChildren) ToggleChildren();
            onOpen?.Invoke();
            onToggle?.Invoke(true);
        }

        /// <summary>
        /// Toggle the menu to be open/closed
        /// </summary>
        public void Toggle()
        {
            if(IsClosed)
            {
                Open();
            }
            else
            {
                Close();
            }
        }

        /// <summary>
        /// Toggle children of transform
        /// </summary>
        private void ToggleChildren()
        {
            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(!IsClosed);
            }
        }
    }
}
