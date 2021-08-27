using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data 
{
    public class PlayerData 
    {
        private float xVelocity;
        private float yVelocity;
        private float zVelocity;
        private float currentSpeed;
        private float walkSpeed;
        private float runSpeed;
        private float turnSmoothTime;
        private bool isGrounded;
        private float jumpHeight;
        
        public PlayerData() {
            XVelocity = 0;
            YVelocity = 0;
            ZVelocity = 0;
            CurrentSpeed = 0;
            WalkSpeed = 7f;
            RunSpeed = 13f;
            TurnSmoothTime = 0.02f;
            JumpHeight = 3.43f;
            IsGrounded = true;
        }

        public Vector3 Velocity {
            get => new Vector3(xVelocity, yVelocity, zVelocity);
        }
        public float XVelocity {
            get => xVelocity;
            set { xVelocity = value; }
        }
        public float YVelocity {
            get => yVelocity;
            set { yVelocity = value; }
        }
        public float ZVelocity {
            get => zVelocity;
            set { zVelocity = value; }
        }
        public float CurrentSpeed {
            get => currentSpeed;
            set { currentSpeed = value; }
        }
        public float WalkSpeed {
            get => walkSpeed;
            set { walkSpeed = value; }
        }
        public float RunSpeed {
            get => runSpeed;
            set { runSpeed = value; }
        }
        public float TurnSmoothTime {
            get => turnSmoothTime;
            set { turnSmoothTime = value; }
        }
        public bool IsGrounded {
            get => isGrounded;
            set { isGrounded = value; }
        }
        public float JumpHeight {
            get => jumpHeight;
            set { jumpHeight = value; }
        }
    }
}