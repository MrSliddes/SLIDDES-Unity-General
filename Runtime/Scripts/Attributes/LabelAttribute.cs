using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SLIDDES.Attributes
{
    /// <summary>
    /// For overriding a unity inspector name
    /// </summary>
    public class LabelAttribute : PropertyAttribute
    {
        public string label;

        public LabelAttribute(string label)
        {
            this.label = label;
        }
    }
}
