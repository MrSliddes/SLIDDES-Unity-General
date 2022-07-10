using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SLIDDES
{
    /// <summary>
    /// A helper class for rotations
    /// </summary>
    public static class QuaternionC
    {
        /// <summary>
        /// Add a normal to existing rotation
        /// </summary>
        /// <param name="transformUp">The transform.up</param>
        /// <param name="hitNormal">The raycast hit.normal</param>
        /// <param name="transformRotation">The transform.rotation</param>
        /// <returns>Quaternion to be assigned to transform.rotation</returns>
        public static Quaternion AddNormalToRotation(Vector3 transformUp, Vector3 hitNormal, Quaternion transformRotation)
        {
            return Quaternion.FromToRotation(transformUp, hitNormal) * transformRotation;
        }

        /// <summary>
        /// Get the direction between 2 points
        /// </summary>
        /// <param name="origin">The origin position</param>
        /// <param name="target">The target position to get the direction to</param>
        /// <returns>Normalized Vector3 direction to target from origin</returns>
        public static Vector3 Direction(Vector3 origin, Vector3 target)
        {
            return (target - origin).normalized;
        }

        /// <summary>
        /// Rotate an object in a direction
        /// </summary>
        /// <param name="origin">The origin transform to rotate</param>
        /// <param name="rotationDirection">The direction to rotate towords</param>
        /// <param name="speed">The speed at which to rotate</param>
        public static void Rotate(Transform origin, Vector3 rotationDirection, float speed, Space space = Space.World)
        {
            origin.Rotate(rotationDirection, speed, space);
        }

        /// <summary>
        /// Rotate an object around a target (like a moon orbiting a planet)
        /// </summary>
        /// <param name="origin">The origin to rotate</param>
        /// <param name="target">The target to rotate around</param>
        /// <param name="rotationDirection">The direction to rotate in</param>
        /// <param name="speed">The speed at which to rotate</param>
        public static void RotateAround(Transform origin, Transform target, Vector3 rotationDirection, float speed)
        {
            origin.RotateAround(target.position, rotationDirection, speed);
        }

        /// <summary>
        /// Rotate an object on its x axis
        /// </summary>
        /// <param name="origin">The origin transform to rotate</param>
        /// <param name="speed">The speed at which to rotate</param>
        public static void RotateOnAxisX(Transform origin, float speed, Space space = Space.World)
        {
            origin.Rotate(Vector3.right, speed, space);
        }

        /// <summary>
        /// Rotate an object on its y axis
        /// </summary>
        /// <param name="origin">The origin transform to rotate</param>
        /// <param name="speed">The speed at which to rotate</param>
        public static void RotateOnAxisY(Transform origin, float speed, Space space = Space.World)
        {
            origin.Rotate(Vector3.up, speed, space);
        }

        /// <summary>
        /// Rotate an object on its z axis
        /// </summary>
        /// <param name="origin">The origin transform to rotate</param>
        /// <param name="speed">The speed at which to rotate</param>
        public static void RotateOnAxisZ(Transform origin, float speed, Space space = Space.World)
        {
            origin.Rotate(Vector3.forward, speed, space);
        }

        /// <summary>
        /// Rotate a transform forward to a target
        /// </summary>
        /// <param name="origin">The origin transform</param>
        /// <param name="target">The target transform to rotate towords</param>
        /// <param name="speed">The speed at which the origin rotates towords the target</param>
        /// <param name="maxMagnitudeDelta">The maximum allowed change in vector magnitude for this rotation</param>
        public static void RotateTowords(Transform origin, Transform target, float speed, float maxMagnitudeDelta = 0)
        {
            origin.rotation = Quaternion.LookRotation(Vector3.RotateTowards(origin.forward, target.position - origin.position, speed, maxMagnitudeDelta));
        }

        /// <summary>
        /// Rotate a origin towords a target in 2D
        /// </summary>
        /// <param name="origin">The origin to rotate towords target</param>
        /// <param name="target">The target to rotate towords</param>
        /// <param name="speed">The speed at which to rotate</param>
        public static void RotateTowords2D(Transform origin, Transform target, float speed)
        {
            Vector3 direction = target.position - origin.position;
            origin.rotation = Quaternion.Slerp(origin.rotation, Quaternion.AngleAxis((Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg), Vector3.forward), speed);
        }

        /// <summary>
        /// Get the quaternion for directly looking at a target
        /// </summary>
        /// <param name="origin">The origin position to rotate</param>
        /// <param name="target">The target position to rotate towords</param>
        /// <returns>Quaternion that looks at target</returns>
        public static Quaternion RotateTowordsInstant(Vector3 origin, Vector3 target)
        {
            return Quaternion.LookRotation((target - origin).normalized);
        }

        /// <summary>
        /// Get the quaternion for directly looking at a target
        /// </summary>
        /// <param name="origin">The origin position to rotate</param>
        /// <param name="target">The target position to rotate towords</param>
        /// <returns>Quaternion that looks at target</returns>
        public static Quaternion RotateTowordsInstant(Vector3 origin, Vector3 target, Vector3 upwards)
        {
            return Quaternion.LookRotation((target - origin).normalized, upwards);
        }

        /// <summary>
        /// Rotate a transform towords a target only on the x axis
        /// </summary>
        /// <param name="origin">The origin transform</param>
        /// <param name="target">The target transform</param>
        public static void RotateTowordsOnAxisX(Transform origin, Transform target)
        {
            origin.LookAt(new Vector3(origin.position.x, target.position.y, target.position.z));
        }

        /// <summary>
        /// Rotate a transform towords a target only on the x axis
        /// </summary>
        /// <param name="origin">The origin transform.position</param>
        /// <param name="target">The target transform.position</param>
        /// <returns>Vector3 to be used in transform.LookAt()</returns>
        public static Vector3 RotateTowordsOnAxisX(Vector3 origin, Vector3 target)
        {
            return new Vector3(origin.x, target.y, target.z);
        }

        /// <summary>
        /// Rotate a transform towords a target only on the y axis
        /// </summary>
        /// <param name="origin">The origin transform</param>
        /// <param name="target">The target transform</param>
        public static void RotateTowordsOnAxisY(Transform origin, Transform target)
        {
            origin.LookAt(new Vector3(target.position.x, origin.position.y, target.position.z));
        }

        /// <summary>
        /// Rotate a transform towords a target only on the y axis
        /// </summary>
        /// <param name="origin">The origin transform.position</param>
        /// <param name="target">The target transform.position</param>
        /// <returns>Vector3 to be used in transform.LookAt()</returns>
        public static Vector3 RotateTowordsOnAxisY(Vector3 origin, Vector3 target)
        {
            return new Vector3(target.x, origin.y, target.z);
        }

        /// <summary>
        /// Rotate a transform towords a target only on the z axis
        /// </summary>
        /// <param name="origin">The origin transform</param>
        /// <param name="target">The target transform</param>
        public static void RotateTowordsOnAxisZ(Transform origin, Transform target)
        {
            origin.LookAt(new Vector3(target.position.x, target.position.y, origin.position.z));
        }

        /// <summary>
        /// Rotate a transform towords a target only on the z axis
        /// </summary>
        /// <param name="origin">The origin transform.position</param>
        /// <param name="target">The target transform.position</param>
        /// <returns>Vector3 to be used in transform.LookAt()</returns>
        public static Vector3 RotateTowordsOnAxisZ(Vector3 origin, Vector3 target)
        {
            return new Vector3(target.x, target.y, origin.z);
        }
    }
}
