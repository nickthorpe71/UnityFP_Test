using System.Collections;
using System.Collections.Generic;

namespace Data 
{
    class PlayerData {
        private float speed;
        private float turnSmoothTime;

        public PlayerData(float _speed, float _turnSmoothTime)
        {
            Speed = _speed;
            TurnSmoothTime = _turnSmoothTime;
        }

        public float Speed 
        {
            get => speed;
            set { speed = value; }
        }
        public float TurnSmoothTime 
        {
            get => turnSmoothTime;
            set { turnSmoothTime = value; }
        }
    }
}