using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SLIDDES.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Color HDR Palette", menuName = "SLIDDES/Scriptable Objects/Colors/Color HDR Palette")]
    public class ColorHDRPalette : ColorPaletteBase
    {
        [Tooltip("Palette for hdr colors")]
        [ColorUsageAttribute(true, true)]
        public Color[] colors;
    }
}
