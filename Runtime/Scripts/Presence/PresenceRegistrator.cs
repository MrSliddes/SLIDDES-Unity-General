using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SLIDDES.Presence
{
    /// <summary>
    /// Automaticly (un)registers to the presenceManager
    /// </summary>
    [AddComponentMenu("SLIDDES/Presence/Presence Registrator")]
    [DisallowMultipleComponent]
    public class PresenceRegistrator : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            PresenceManager.Register(gameObject);
        }

        private void OnDestroy()
        {
            PresenceManager.UnRegister(gameObject);
        }
    }
}
