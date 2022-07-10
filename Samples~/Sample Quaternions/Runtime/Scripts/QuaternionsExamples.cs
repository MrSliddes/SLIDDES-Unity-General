using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SLIDDES;

namespace SLIDDES.Samples.Quaternions
{
    [ExecuteInEditMode]
    public class QuaternionsExamples : MonoBehaviour
    {
        public float rotateSpeed = 10;

        [Header("Rotate Towords Target On X")]
        public Transform rotateTowordsTargetX;
        public Transform rotateTowordsTargetXTarget;
        [Header("Rotate Towords Target On Y")]
        public Transform rotateTowordsTargetY;
        public Transform rotateTowordsTargetYTarget;
        [Header("Rotate Towords Target On Z")]
        public Transform rotateTowordsTargetZ;
        public Transform rotateTowordsTargetZTarget;
        [Header("Rotate Towords Target")]
        public Transform rotateTowordsTarget;
        public Transform rotateTowordsTargetTarget;
        [Header("Rotate")]
        public Transform rotate;
        public Transform rotateX;
        public Transform rotateY;
        public Transform rotateZ;
        [Header("2D")]
        public Transform rotate2D;
        public Transform rotate2DTarget;

        private float speed;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            speed = rotateSpeed * Time.deltaTime;
            Rotate();
            Rotate2D();
            RotateTowordsTargetOnAxis();
        }

        public void Rotate()
        {
            QuaternionC.Rotate(rotate, new Vector3(1, 1, 1), speed);
            QuaternionC.RotateOnAxisX(rotateX, speed);
            QuaternionC.RotateOnAxisY(rotateY, speed);
            QuaternionC.RotateOnAxisZ(rotateZ, speed);
        }

        public void RotateTowordsTargetOnAxis()
        {
            // X axis
            QuaternionC.RotateTowordsOnAxisX(rotateTowordsTargetX, rotateTowordsTargetXTarget);
            // Y axis
            QuaternionC.RotateTowordsOnAxisY(rotateTowordsTargetY, rotateTowordsTargetYTarget);
            // Z axis
            QuaternionC.RotateTowordsOnAxisZ(rotateTowordsTargetZ, rotateTowordsTargetZTarget);
            // All
            QuaternionC.RotateTowords(rotateTowordsTarget, rotateTowordsTargetTarget, 10 * Time.deltaTime);
        }

        public void Rotate2D()
        {
            QuaternionC.RotateTowords2D(rotate2D, rotate2DTarget, speed);
        }
    }
}
