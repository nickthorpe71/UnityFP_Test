using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculations 
{
    public static class MoveCalc 
    {
        public static Vector3 CalcInputDirection(float x, float y, float z) => new Vector3(x, y, z).normalized;
        
        public static Vector3 CalcMoveDirection(float targetAngle) 
            => (Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward).normalized;

        public static Vector3 CalcVelocity(Vector3 direction, float speed = 1) => direction * speed * Time.deltaTime;
        
        public static float CalcTargetAngleRelativeToCamera(Vector3 direction, float cameraRotation)
            => Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraRotation;

        public static Quaternion CalcRotation(float targetAngle, float currentYRotation, float smoothTime) {
            float turnSmoothVelocity = 0.0f; 
            float angle = Mathf.SmoothDampAngle(currentYRotation, targetAngle, ref turnSmoothVelocity, smoothTime);
            return Quaternion.Euler(0f, angle, 0f);
        }
    }
}