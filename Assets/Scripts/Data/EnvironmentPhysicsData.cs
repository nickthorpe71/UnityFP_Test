using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data 
{
    public class EnvironmentPhysicsData 
    {
        private float groundCheckDistance = 0.2f;
        private float gravity = -9.81f;

        public EnvironmentPhysicsData(float _gravity, float _groundCheckDistance) {
            gravity = _gravity;
            groundCheckDistance = _groundCheckDistance;
        }

        public float Gravity {
            get => gravity;
            set { gravity = value; }
        }
        public float GroundCheckDistance {
            get => groundCheckDistance;
            set { groundCheckDistance = value; }
        }

    }
}