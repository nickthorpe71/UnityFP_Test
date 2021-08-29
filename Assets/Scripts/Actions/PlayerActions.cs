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
        public static void HandlePlayerInput(PlayerData playerData, float gravity, Action<IEnumerator> startRoutine)
        {
            HandleDirectionalInput(playerData, Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            HandleJumpInput(Input.GetKeyDown(KeyCode.Space), playerData, gravity);
            HandleMeleeInput(Input.GetKeyDown(KeyCode.Mouse0), playerData, startRoutine);
            HandleRangedInput(Input.GetKeyDown(KeyCode.Mouse1), playerData, startRoutine);
        }

        private static void HandleDirectionalInput(PlayerData playerData, float horizontal, float vertical)
        {
            Vector3 inputDirection = CalcInputDirection(horizontal, 0f, vertical);

            // If the player has input movement
            if (inputDirection.magnitude >= 0.1)
                ExecuteDirectionalMovement(playerData, inputDirection);
            else
                ExecuteIdle(playerData);
        }

        private static void HandleJumpInput(bool didPressJump, PlayerData playerData, float gravity) 
        {
            if (playerData.IsGrounded && didPressJump)
                playerData.YVelocity = CalcJump(playerData.JumpHeight, gravity);
        }

        private static void HandleMeleeInput(bool didPressLeftMouse, PlayerData playerData, Action<IEnumerator> startRoutine)
        {
            if(didPressLeftMouse && playerData.CanAttack)
                startRoutine(ExecuteMeleeAttack(playerData));
        }

        private static void HandleRangedInput(bool didPressRightMouse, PlayerData playerData, Action<IEnumerator> startRoutine)
        {
            if(didPressRightMouse && playerData.CanAttack)
                startRoutine(ExecuteMeleeAttack(playerData));
        }

        // EXECUTION
        private static IEnumerator ExecuteMeleeAttack(PlayerData playerData) 
        {
            playerData.CanAttack = false;
            playerData.ActiveSword.SetActive(true);
            playerData.InactiveSword.SetActive(false);
            playerData.Anim.SetLayerWeight(playerData.Anim.GetLayerIndex("Attack Layer"), 1);
            playerData.Anim.SetTrigger("SwordAttack");

            yield return new WaitForSeconds(playerData.AttackCooldown);
            playerData.Anim.SetLayerWeight(playerData.Anim.GetLayerIndex("Attack Layer"), 0);
            playerData.CanAttack = true;
            playerData.ActiveSword.SetActive(false);
            playerData.InactiveSword.SetActive(true);
        }

        public static void ExecuteDirectionalMovement(PlayerData playerData, Vector3 direction)
        {
            playerData.CurrentSpeed = Input.GetKey(KeyCode.LeftShift) ? playerData.RunSpeed : playerData.WalkSpeed;
            float targetAngle = CalcTargetAngleRelativeToCamera(direction, playerData.Cam.eulerAngles.y);

            playerData.Player.transform.rotation = CalcRotation(
                targetAngle,
                playerData.Player.transform.eulerAngles.y,
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

