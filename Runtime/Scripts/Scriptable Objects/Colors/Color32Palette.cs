using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SLIDDES.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Color32 Palette", menuName = "SLIDDES/Scriptable Objects/Colors/Color32 Palette")]
    public class Color32Palette : ColorPaletteBase
    {
        public Color32[] colors;
    }
}
