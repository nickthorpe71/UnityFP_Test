using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using static Calculations.MoveCalc;

namespace Actions 
{
    public static class EnvironmentPhysicsActions 
    {
        public static void UpdateGravity(
            Transform playerTransform,
            PlayerData playerData,
            float gravity,
            float groundCheckDistance,
            LayerMask groundMask) {
            if (Physics.CheckSphere(playerTransform.position, groundCheckDistance, groundMask)) 
                playerData.YVelocity += gravity * Time.deltaTime;
            else
                playerData.YVelocity = -2f;
        }
    }
}

