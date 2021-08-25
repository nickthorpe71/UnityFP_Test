using System.Collections;
using System.Collections.Generic;

namespace Data 
{
    class PlayerData {
        private float walkSpeed;
        private float runSpeed;
        private float turnSmoothTime;

        public PlayerData(float _walkSpeed, float _runSpeed, float _turnSmoothTime)
        {
            WalkSpeed = _walkSpeed;
            RunSpeed = _runSpeed;
            TurnSmoothTime = _turnSmoothTime;
        }

        public float WalkSpeed 
        {
            get => walkSpeed;
            set { walkSpeed = value; }
        }
        public float RunSpeed 
        {
            get => runSpeed;
            set { runSpeed = value; }
        }
        public float TurnSmoothTime 
        {
            get => turnSmoothTime;
            set { turnSmoothTime = value; }
        }
    }
}