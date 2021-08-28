using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

namespace Actions 
{
    public static class EnvironmentPhysicsActions 
    {
        public static void UpdateGravity(
            Transform playerTransform,
            PlayerData playerData,
            float gravity,
            float groundCheckDistance,
            LayerMask groundMask)
        {
            playerData.IsGrounded = Physics.CheckSphere(playerTransform.position, groundCheckDistance, groundMask);

            if (playerData.IsGrounded && playerData.YVelocity < 0)
                playerData.YVelocity = -2f;

            playerData.YVelocity += gravity * Time.deltaTime;
        }
    }
}

