using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SLIDDES
{
    public static class Vector3Extentions
    {
        /// <summary>
        /// Get the right property of a vector
        /// </summary>
        /// <credit>https://answers.unity.com/questions/228203/getting-vector-which-is-pointing-to-the-rightleft.html</credit>
        /// <param name="normalizedValue"></param>
        /// <param name="up"></param>
        /// <returns></returns>
        public static Vector3 Right(this Vector3 normalizedValue, Vector3 up)
        {
            return Vector3.Cross(up, normalizedValue);
        }
    }
}
