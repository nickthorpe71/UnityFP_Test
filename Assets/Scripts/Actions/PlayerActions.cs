using System;
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
            controller.Move(playerData.Velocity * Time.deltaTime);
        }

        // INPUT HANDLERS
        public static void HandlePlayerInput(
            Transform playerTransform,
            PlayerData playerData,
            float cameraYRotation,
            float gravity,
            Animator playerAnimator,
            Action<IEnumerator> startRoutine)
        {
            HandleDirectionalInput(playerTransform, playerData, cameraYRotation, Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            HandleJumpInput(Input.GetKeyDown(KeyCode.Space), playerData, gravity);
            HandleMeleeInput(Input.GetKeyDown(KeyCode.Mouse0), playerData, playerAnimator, startRoutine);
        }

        private static void HandleDirectionalInput(
            Transform playerTransform,
            PlayerData playerData,
            float cameraYRotation,
            float horizontal,
            float vertical)
        {
            Vector3 inputDirection = CalcInputDirection(horizontal, 0f, vertical);

            // If the player has input movement
            if (inputDirection.magnitude >= 0.1)
                ExecuteDirectionalMovement(playerTransform, playerData, cameraYRotation, inputDirection);
            else
                ExecuteIdle(playerData);
        }

        private static void HandleJumpInput(bool didPressJump, PlayerData playerData, float gravity) 
        {
            if (playerData.IsGrounded && didPressJump)
                playerData.YVelocity = CalcJump(playerData.JumpHeight, gravity);
        }

        private static void HandleMeleeInput(bool didPressLeftMouse, PlayerData playerData, Animator animator, Action<IEnumerator> startRoutine)
        {
            if(didPressLeftMouse && playerData.CanAttack)
            {
                startRoutine(ExecuteMeleeAttack(animator, playerData));
            }
        }

        private static IEnumerator ExecuteMeleeAttack(Animator animator, PlayerData playerData) 
        {
            Debug.Log("made it");
            playerData.CanAttack = false;
            animator.SetLayerWeight(animator.GetLayerIndex("Attack Layer"), 1);
            animator.SetTrigger("SwordAttack");

            yield return new WaitForSeconds(playerData.AttackCooldown);
            animator.SetLayerWeight(animator.GetLayerIndex("Attack Layer"), 0);
            playerData.CanAttack = true;
        }

        // EXECUTION
        public static void ExecuteDirectionalMovement(
            Transform playerTransform,
            PlayerData playerData,
            float cameraYRotation,
            Vector3 direction)
        {
            playerData.CurrentSpeed = Input.GetKey(KeyCode.LeftShift) ? playerData.RunSpeed : playerData.WalkSpeed;
            float targetAngle = CalcTargetAngleRelativeToCamera(direction, cameraYRotation);

            playerTransform.rotation = CalcRotation(
                targetAngle,
                playerTransform.eulerAngles.y,
                playerData.TurnSmoothTime
            );

            Vector3 directionalMovementVector = CalcMoveDirection(targetAngle);
            playerData.XVelocity = directionalMovementVector.x * playerData.CurrentSpeed;
            playerData.ZVelocity = directionalMovementVector.z * playerData.CurrentSpeed;
        }

        public static void ExecuteIdle(PlayerData playerData)
        {
            playerData.CurrentSpeed = 0f;
            playerData.XVelocity = 0f;
            playerData.ZVelocity = 0f;
        }
    }
}

