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
        /// Rotate a origin.rotation to that of the target.rotation
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="target"></param>
        /// <param name="speed">How fast the rotation is. Set to 1 for instant rotation</param>
        public static void CopyRotation(Transform origin, Transform target, float speed)
        {
            origin.rotation = Quaternion.Slerp(origin.rotation, target.rotation, speed);
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
        /// Rotate an transform on a specific axis
        /// </summary>
        /// <param name="axis">The axis to rotate on</param>
        /// <param name="origin">The transform to rotate</param>
        /// <param name="speed">The speed of the rotation</param>
        /// <param name="space">The space in which to operate</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static void RotateOnAxis(Axis axis, Transform origin, float speed, Space space = Space.World)
        {
            switch(axis)
            {
                case Axis.x:
                    origin.Rotate(Vector3.right, speed, space);
                    break;
                case Axis.y:
                    origin.Rotate(Vector3.up, speed, space);
                    break;
                case Axis.z:
                    origin.Rotate(Vector3.forward, speed, space);
                    break;
                default: throw new System.ArgumentOutOfRangeException("axis");
            }
        }


        /// <summary>
        /// Rotate the transform.forward towords the target
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="target"></param>
        public static void RotateTowords(Transform origin, Transform target)
        {
            origin.rotation = Quaternion.LookRotation((target.position - origin.position).normalized);
        }

        /// <summary>
        /// Rotate the transform.forward towords the target
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="target"></param>
        public static void RotateTowords(Transform origin, Transform target, Vector3 upwards)
        {
            origin.rotation = Quaternion.LookRotation((target.position - origin.position).normalized, upwards);
        }

        /// <summary>
        /// Rotate the transform.forward towords the target
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
        /// Rotate towords the target on a specific axis
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="origin"></param>
        /// <param name="target"></param>
        /// <param name="speed"></param>
        /// <param name="maxMagnitudeDelta"></param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static void RotateTowordsOnAxis(Axis axis, Transform origin, Transform target, float speed = 1, float maxMagnitudeDelta = 0)
        {
            Vector3 originPosition = origin.position;
            Vector3 targetPosition = target.position;

            switch(axis)
            {
                case Axis.x:
                    originPosition.x = 0;
                    targetPosition.x = 0;
                    break;
                case Axis.y:
                    originPosition.y = 0;
                    targetPosition.y = 0;
                    break;
                case Axis.z:
                    originPosition.z = 0;
                    targetPosition.z = 0;
                    break;
                default: throw new System.ArgumentOutOfRangeException("axis");
            }

            origin.rotation = Quaternion.LookRotation(Vector3.RotateTowards(origin.forward, targetPosition - originPosition, speed, maxMagnitudeDelta));
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

        public enum Axis
        {
            x,
            y,
            z
        }
    }
}
