using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data 
{
    public class PlayerData 
    {
        private float currentSpeed;
        private float walkSpeed;
        private float runSpeed;
        private float turnSmoothTime;
        private bool isGrounded;
        private float xVelocity;
        private float yVelocity;
        private float zVelocity;

        public PlayerData(float _walkSpeed, float _runSpeed, float _turnSmoothTime) {
            CurrentSpeed = 0;
            WalkSpeed = _walkSpeed;
            RunSpeed = _runSpeed;
            TurnSmoothTime = _turnSmoothTime;
            IsGrounded = true;
            XVelocity = 0;
            YVelocity = 0;
            ZVelocity = 0;
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
    }
}