using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

namespace Actions
{
    public static class PlayerAnimation
    {
        public static void Animate(Animator playerAnimator, PlayerData playerData) 
        {
            if (playerData.IsGrounded)
            {
                float speedPercent = playerData.CurrentSpeed / playerData.RunSpeed;
                playerAnimator.SetFloat("Speed", speedPercent, 0.2f, Time.deltaTime);
                playerAnimator.ResetTrigger("Jump");
                playerAnimator.SetBool("Fall", false);
            }
            else 
            {
                playerAnimator.SetBool("Fall", true);

                if (playerData.YVelocity >= 0)
                    playerAnimator.SetTrigger("Jump");
            }
        }
    }
}

