using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data 
{
    public class EnvironmentPhysicsData 
    {
        private float groundCheckDistance;
        private float gravity;

        public EnvironmentPhysicsData() {
            gravity = -33.81f;
            groundCheckDistance = 0.2f;
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