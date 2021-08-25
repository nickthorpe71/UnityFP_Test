using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using static Calculations.MoveCalc;

namespace Actions 
{
    public static class PlayerActions 
    {
        // PHYSICS
        public static void UpdatePlayerVelocity(CharacterController controller, PlayerData playerData) {
            controller.Move(CalcVelocity(playerData.Velocity, playerData.CurrentSpeed));
        }

        // INPUT HANDLERS
        public static void HandlePlayerInput(Transform playerTransform, PlayerData playerData, float cameraYRotation) {
            HandleDirectionalInput(
                playerTransform,
                playerData,
                cameraYRotation,
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")
            );
            HandleSprintInput(Input.GetKey(KeyCode.LeftShift), playerData);
            HandleJumpInput();
        }
        public static void HandleDirectionalInput(
            Transform playerTransform,
            PlayerData playerData,
            float cameraYRotation,
            float horizontal,
            float vertical) {
            Vector3 inputDirection = CalcInputDirection(horizontal, 0f, vertical);

            // If the player has input movement
            if (inputDirection.magnitude >= 0.1)
                ExecuteDirectionalMovement(playerTransform, playerData, cameraYRotation, inputDirection);
            else
                ExecuteIdle(playerData);
        }
        public static void HandleSprintInput(bool isSprinting, PlayerData playerData) {
            playerData.CurrentSpeed = isSprinting ? playerData.RunSpeed : playerData.WalkSpeed;
        }
        public static void HandleJumpInput() {

        }

        // EXECUTION ACTIONS
        public static void ExecuteDirectionalMovement(
            Transform playerTransform,
            PlayerData playerData,
            float cameraYRotation,
            Vector3 direction) {
            float targetAngle = CalcTargetAngleRelativeToCamera(direction, cameraYRotation);

            playerTransform.rotation = CalcRotation(
                targetAngle,
                playerTransform.eulerAngles.y,
                playerData.TurnSmoothTime
            );

            Vector3 directionalMovementVector = CalcMoveDirection(targetAngle);
            playerData.XVelocity = directionalMovementVector.x;
            playerData.ZVelocity = directionalMovementVector.z;
        }
        public static void ExecuteIdle(PlayerData playerData) {
            playerData.XVelocity = 0;
            playerData.ZVelocity = 0;
        }
    }
}

