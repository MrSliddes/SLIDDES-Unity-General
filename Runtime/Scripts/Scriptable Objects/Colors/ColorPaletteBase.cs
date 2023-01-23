using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SLIDDES.ScriptableObjects
{
    /// <summary>
    /// Base class for a SO color palette
    /// </summary>
    public abstract class ColorPaletteBase : ScriptableObject
    {
        [Tooltip("Description of what this palette is for")]
        [TextArea(1, 10)]
        public string description;
    }
}
