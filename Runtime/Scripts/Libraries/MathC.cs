using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SLIDDES
{
    /// <summary>
    /// Contains custom math related functions
    /// </summary>
    public class MathC
    {
        // Functions sorted on alfabetic order

        /// <summary>
        /// Converts a bool to int 
        /// </summary>
        /// <param name="value">The value to convert to int</param>
        /// <param name="falseIsZero">[True] If value is fasle, return 0 instead of -1.</param>
        /// <returns>-1 if value is false, 1 if value is true, or 0 if falseIsZero is set to true</returns>
        public static int BoolToInt(bool value, bool falseIsZero = false)
        {
            if(falseIsZero)
            {
                // If value is fasle, return 0 instead of -1
                if(value) return 1;
                return 0;
            }
            else
            {
                if(value) return 1;
                return -1;
            }
        }

        /// <summary>
        /// Calculates the velocity an object needs to hit a target with a curve
        /// </summary>
        /// <param name="origin">The position of the object that receives the velocity</param>
        /// <param name="target">The target position to hit</param>
        /// <param name="time">Time scale, default is 1</param>
        /// <returns>The velocity the rigidbody needs in order to hit the target</returns>
        /// <seealso cref="TimePointCalculateVelocityToHitTarget"/>
        public static Vector3 CalculateVelocityToHitTarget(Vector3 origin, Vector3 target, float time = 1)
        {
            Vector3 distance = target - origin;
            Vector3 distanceXz = distance;
            distanceXz.y = 0;

            float sY = distance.y;
            float sXz = distanceXz.magnitude;

            float Vxz = sXz * time;
            float Vy = (sY / time) + (0.5f * UnityEngine.Mathf.Abs(Physics.gravity.y) * time);

            Vector3 result = distanceXz.normalized;
            result *= Vxz;
            result.y = Vy;
            return result;
        }

        /// <summary>
        /// Enlarges the array values to have bigger values based on its min/max value
        /// </summary>
        /// <param name="array">The array to enlarge the values</param>
        /// <param name="mapValueMin">The minimum value to map to</param>
        /// <param name="mapValueMax">The maximum value to map to</param>
        public static void EnlargeArrayValues(ref float[] array, float mapValueMin, float mapValueMax)
        {
            float minValue = 0;
            float maxValue = 0;
            for(int i = 0; i < array.Length; i++)
            {
                if(array[i] > maxValue)
                {
                    maxValue = array[i];
                }
                else if(array[i] < minValue)
                {
                    minValue = array[i];
                }
            }

            // Now that we got min and max values map all [] values to -1, 1 based on min max
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = Map(array[i], minValue, maxValue, -1, 1);
            }
        }
        
        /// <summary>
        /// Converts an int to bool (true or false)
        /// </summary>
        /// <param name="value">Value to convert to bool</param>
        /// <param name="zeroIsFalse">[True] the value 0 returns false. [False] the value 0 returns true (default)</param>
        /// <returns>True if value is less than 0, false if value is equal of greater then 0, or false if zeroIsFalse is set to true and value is 0</returns>
        public static bool IntToBool(int value, bool zeroIsFalse = false)
        {
            if(zeroIsFalse)
            {
                // 0 <= is false, 0 > is true
                if(value <= 0) return false;
                return true;
            }
            else
            {
                // -1 <= is false, 0 >= is true
                if(value < 0) return false;
                return true;
            }
        }

        /// <summary>
        /// Convert inch value to metric value
        /// </summary>
        /// <param name="inchValue">The inch value to convert to metric</param>
        /// <returns>Metric float</returns>
        public static float InchToMetric(float inchValue)
        {
            return inchValue * 25.4f;
        }

        /// <summary>
        /// Convert Kg/m to Lbs (!NOT Lbs/ft!) 1 kg/m = 2.20462262185 lbs
        /// </summary>
        /// <param name="kgmValue">The Kg/m value to convert to lbs/ft</param>
        /// <returns>Lbs/ft float value</returns>
        public static float KgmToLbs(float kgmValue)
        {
            // https://www.csharp-console-examples.com/basic/kg-to-lb-in-c-convert-kilograms-to-pounds-in-c/
            return kgmValue * 2.20462262185f;
        }

        /// <summary>
        /// Convert Kg/m to lbs/ft
        /// </summary>
        /// <param name="kgmValue"></param>
        /// <returns>Lbs/ft</returns>
        public static float KgmToLbsFt(float kgmValue)
        {
            //https://www.convertunits.com/from/kg/m/to/lb/ft
            //https://www.convertunits.com/from/lb/ft/to/kg/m
            return kgmValue * 0.67196897675131f;
        }

        /// <summary>
        /// Convert Lbs/ft to Kg/m
        /// </summary>
        /// <param name="lbsFt"></param>
        /// <returns></returns>
        public static float LbsFtToKgm(float lbsFtValue)
        {
            return lbsFtValue / 0.67196897675131f;
        }

        /// <summary>
        /// Convert Lbs to kg/m. 1 kg/m = 2.20462262185 lbs
        /// </summary>
        /// <param name="lbsValue">The lbs value to convert to kg/m</param>
        /// <returns>kg/m in float</returns>
        public static float LbsToKgm(float lbsValue)
        {
            return lbsValue / 2.20462262185f;
        }

        /// <summary>
        /// Maps a value between 2 new values
        /// </summary>
        /// <param name="valueToMap">The value to map</param>
        /// <param name="oldMin">The old minimum value the valueToMap could be</param>
        /// <param name="oldMax">The old maximum value the valueToMap could be</param>
        /// <param name="newMin">The new minimum value the valueToMap can be</param>
        /// <param name="newMax">The new maximum value the valueToMap can be</param>
        /// <returns></returns>
        public static float Map(float valueToMap, float oldMin, float oldMax, float newMin, float newMax)
        {
            //https://forum.unity.com/threads/mapping-or-scaling-values-to-a-new-range.180090/
            float oldRange = oldMax - oldMin;
            float newRange = newMax - newMin;
            return (((valueToMap - oldMin) * newRange) / oldRange) + newMin;
        }

        /// <summary>
        /// Convert metric float to inch
        /// </summary>
        /// <param name="metricValue">The metric value to convert to inch</param>
        /// <returns>Inch float</returns>
        public static float MetricToInch(float metricValue)
        {
            return metricValue / 25.4f;
        }

        /// <summary>
        /// Mirror a vector 2 x/y "horizontally or vertically"
        /// </summary>
        /// <param name="vector2">The vector to mirror</param>
        /// <param name="mirrorHorizontally">True: mirror it horizontally. Flase: mirror it vertically</param>
        /// <returns>The mirrored Vector2</returns>
        /// <seealso cref="RotateVector2"/>
        public static Vector2 MirrorVector2(Vector2 vector2, bool mirrorHorizontally = true)
        {
            // Mirror rules
            // Mirror horizontally: x * -1 
            // Mirror vertically: y * -1
            return mirrorHorizontally ? new Vector2(vector2.x * -1, vector2.y) : new Vector2(vector2.x, vector2.y * -1);
        }

        /// <summary>
        /// Mirror a vector 2 array x/y "horizontally or vertically"
        /// </summary>
        /// <param name="array"></param>
        /// <param name="mirrorHorizontally"></param>
        /// <returns></returns>
        public static Vector2[] MirrorVector2(Vector2[] array, bool mirrorHorizontally = true)
        {
            // Mirror rules
            // Mirror horizontally: x * -1 
            // Mirror vertically: y * -1
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = mirrorHorizontally ? new Vector2(array[i].x * -1, array[i].y) : new Vector2(array[i].x, array[i].y * -1);
            }
            return array;
        }

        /// <summary>
        /// Get position of the edge of a circle based on values
        /// </summary>
        /// <param name="center">The center position of the circle</param>
        /// <param name="radius">The radius of the circle</param>
        /// <param name="angle">The angle of the circle where you want the position to be (positive or negative). Circle starts at the +y axis (12'oclock) and goes clockwise</param>
        /// <returns>Vector3 position on the edge of the circle</returns>
        public static Vector3 PositionOnCircle(Vector3 center, float radius, float angle)
        {
            Vector3 pos;
            pos.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
            pos.y = center.y + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
            pos.z = center.z;
            return pos;
        }

        /// <summary>
        /// Rotate a vector2 by "90deg/180deg/270deg"
        /// </summary>
        /// <param name="vector2">Vector2 to rotate</param>
        /// <param name="rotationAmount">0 deg: n/a, 90deg: 1, 180deg: 2, 270deg: 3</param>
        /// <returns>The rotated Vector2</returns>
        /// <example>
        /// Vector2 foo = new Vector2(1, 0);
        /// Vector2 result = MathC.RotateVector2(foo, 1);
        /// result is: (0, -1)
        /// </example>
        public static Vector2 RotateVector2(Vector2 vector2, int rotationAmount)
        {
            switch(rotationAmount)
            {
                case 1: return new Vector2(vector2.y, vector2.x * -1);
                case 2: return new Vector2(vector2.x * -1, vector2.y * -1);
                case 3: return new Vector2(vector2.y * -1, vector2.x);
                default: Debug.LogError("[MathC] RotateVector2: rotationAmount not correct. Correct range is 1, 2 or 3. Tried to use range: " + rotationAmount); break;
            }
            return vector2;
        }

        /// <summary>
        /// Rotate a vector2 array by "90deg/180deg/270deg"
        /// </summary>
        /// <param name="array">Array to rotate</param>
        /// <param name="rotationAmount">0 deg: n/a, 90deg: 1, 180deg: 2, 270deg: 3</param>
        /// <returns>The rotated Vector2 array</returns>
        /// <example>
        /// Vector2[] foo = new Vector2[4] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 2) };
        /// Vector2[] result = MathC.RotateVector2(foo, 1);
        /// result is: { new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, -1), new Vector2(2, -1) }
        /// </example>
        public static Vector2[] RotateVector2(Vector2[] array, int rotationAmount)
        {
            Vector2[] newArray = new Vector2[array.Length]; // This is unnessesary?
            System.Array.Copy(array, newArray, array.Length);
            // Rotate rules
            // Rotate up: is array values
            // Rotate right: swap x & y and x * -1
            // Rotate down: x * -1 & y * -1
            // Rotate left: swap x & y and y * -1
            switch(rotationAmount)
            {
                case 1:
                    // Rotate to the right
                    for(int i = 0; i < newArray.Length; i++)
                    {
                        newArray[i] = new Vector2(newArray[i].y, newArray[i].x * -1);
                    }
                    break;
                case 2:
                    // Rotate down
                    for(int i = 0; i < newArray.Length; i++)
                    {
                        newArray[i] = new Vector2(newArray[i].x * -1, newArray[i].y * -1);
                    }
                    break;
                case 3:
                    // Rotate to the left
                    for(int i = 0; i < newArray.Length; i++)
                    {
                        newArray[i] = new Vector2(newArray[i].y * -1, newArray[i].x);
                    }
                    break;
                default: Debug.LogError("[MathC] RotateVector2: rotationAmount not correct. Correct range is 1, 2 or 3. Tried to use range: " + rotationAmount); break;
            }

            return newArray;
        }

        /// <summary>
        /// Convert big array to smaller array
        /// </summary>
        /// <param name="array">The array to short</param>
        /// <param name="newArrayLength">The new length of the array</param>
        public static void ShortArray(ref float[] array, int newArrayLength)
        {
            // Get the int that tells how many ints have to be averaged into 1 number
            int averageLenth = array.Length / newArrayLength;

            List<float> tempList = new List<float>();
            // Loop trough array
            float averageNumber = 0;
            for(int i = 0; i < array.Length; i++) // IMPROVE can this be 2 for loops? 1 for skipping avg length, 1 for adding index i
            {
                // add index to avarageNumber
                averageNumber += array[i];

                // If i is 0 as result of being devided by averageLength, add averageNumber / averageLength to tempList
                if(i % averageLenth == 0 && i != 0)
                {
                    float newValue = Mathf.Clamp(averageNumber / (float)averageLenth, -1f, 1f);
                    tempList.Add(newValue);
                    averageNumber = 0;
                }
            }

            array = tempList.ToArray();
        }

        /// <summary>
        /// Shuffle a list
        /// </summary>
        /// <typeparam name="T">The type of the list</typeparam>
        /// <param name="list">The list to shuffle</param>
        /// <returns>The shuffeld list</returns>
        public static List<T> ShuffleList<T>(List<T> list) // does this belong here tho?
        {
            for(int i = 0; i < list.Count; i++)
            {
                T temp = list[i];
                int randomIndex = UnityEngine.Random.Range(i, list.Count);
                list[i] = list[randomIndex];
                list[randomIndex] = temp;
            }

            return list;
        }

        /// <summary>
        /// Snap values to given grid values
        /// </summary>
        /// <param name="pos">The position to snap</param>
        /// <param name="grid">The grid increments</param>
        /// <returns>The snapped vector2 value</returns>
        public static Vector2 SnapToGrid(Vector2 pos, Vector2 grid)
        {
            return new Vector2(SnapValue(pos.x, grid.x), SnapValue(pos.y, grid.y));
        }

        /// <summary>
        /// Snaps values to given grid values
        /// </summary>
        /// <param name="pos">The position to snap</param>
        /// <param name="grid">The grid increments</param>
        /// <returns>The snapped vector3 value</returns>
        public static Vector3 SnapToGrid(Vector3 pos, Vector3 grid)
        {
            return new Vector3(SnapValue(pos.x, grid.x), SnapValue(pos.y, grid.y), SnapValue(pos.z, grid.z));
        }

        /// <summary>
        /// Snap a value to given snap value
        /// </summary>
        /// <param name="v">Value to snap</param>
        /// <param name="snap">The snap increment</param>
        /// <returns>The snapped value</returns>
        public static float SnapValue(float v, float snap)
        {
            return Mathf.Round(v / snap) * snap;
        }

        /// <summary>
        /// Get a vector3 from a point in time from the CalculatedVelocityToHitTarget
        /// </summary>
        /// <param name="calculatedVelocity">The vector3 from CalculateVelocityToHitTarget</param>
        /// <param name="origin">The origin position of the object that got the velocity</param>
        /// <param name="time">The point in time</param>
        /// <returns>Vector3 relative to the time value</returns>
        /// <seealso cref="CalculateVelocityToHitTarget"/>
        public static Vector3 TimePointCalculateVelocityToHitTarget(Vector3 calculatedVelocity, Vector3 origin, float time)
        {
            Vector3 vXZ = calculatedVelocity;
            vXZ.y = 0;

            Vector3 result = origin + calculatedVelocity * time;
            result.y = (-0.5f * Mathf.Abs(Physics.gravity.y) * (time * time)) + (calculatedVelocity.y * time) + origin.y;
            return result;
        }

        /// <summary>
        /// For getting the value difference between 2 values (and you forgot how to do it)
        /// </summary>
        /// <param name="a">Value a to compare</param>
        /// <param name="b">Value b to compare</param>
        /// <returns>The float difference between the 2 values</returns>
        /// <seealso cref="Vector2.Distance(Vector2, Vector2)"/>
        /// <seealso cref="Vector3.Distance(Vector3, Vector3)"/>
        public static float ValueDiff(float a, float b)
        {
            return Mathf.Abs(a - b);
        }
    }
}