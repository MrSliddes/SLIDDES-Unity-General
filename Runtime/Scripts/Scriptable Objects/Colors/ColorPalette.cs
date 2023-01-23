using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SLIDDES.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Color Palette", menuName = "SLIDDES/Scriptable Objects/Colors/Color Palette")]
    public class ColorPalette : ColorPaletteBase
    {
        public Color[] colors;
    }
}
