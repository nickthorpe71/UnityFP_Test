using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data 
{
    public class PlayerData 
    {
        // MOVEMENT + JUMP
        private float xVelocity;
        private float yVelocity;
        private float zVelocity;
        private float currentSpeed;
        private float walkSpeed = 7f;
        private float runSpeed = 13f;
        private float turnSmoothTime = 0.02f;
        private float jumpHeight = 3.43f;
        private bool isGrounded;

        // ATTACK
        private float meleeCooldown = 0.93f;
        private float rangedCooldown = 1.12f;
        private bool canMeleeAttack;
        private bool canRangedAttack;
        private bool aiming;
        

        // GAME REFS
        private Transform cam;
        private GameObject player;
        private CharacterController controller;
        private Animator anim;
        private GameObject activeSword;
        private GameObject inactiveSword;
        private GameObject activeBow;
        private GameObject inactiveBow;
        
        public PlayerData(
            Transform _cam,
            GameObject _player,
            CharacterController _controller, 
            Animator _anim,
            GameObject _activeSword,
            GameObject _inactiveSword,
            GameObject _activeBow,
            GameObject _inactiveBow) 
        {
            // MOVEMENT + JUMP
            XVelocity = 0;
            YVelocity = 0;
            ZVelocity = 0;
            CurrentSpeed = 0;
            IsGrounded = true;

            // ATTACK
            CanMeleeAttack = true;
            CanRangedAttack = true;
            Aiming = false;

            // IN GAME REFS
            Cam = _cam;
            Player = _player;
            Controller = _controller;
            Anim = _anim;
            ActiveSword = _activeSword;
            InactiveSword = _inactiveSword;
            ActiveBow = _activeBow;
            InactiveBow = _inactiveBow;
        }

        // MOVEMENT + JUMP
        public Vector3 Velocity { get => new Vector3(xVelocity, yVelocity, zVelocity); }
        public float XVelocity { get => xVelocity; set { xVelocity = value; } }
        public float YVelocity { get => yVelocity; set { yVelocity = value; } }
        public float ZVelocity { get => zVelocity; set { zVelocity = value; } }
        public float CurrentSpeed { get => currentSpeed; set { currentSpeed = value; } }
        public float WalkSpeed { get => walkSpeed; }
        public float RunSpeed { get => runSpeed; }
        public float TurnSmoothTime { get => turnSmoothTime; }
        public bool IsGrounded { get => isGrounded; set { isGrounded = value; } }
        public float JumpHeight { get => jumpHeight; }

        // ATTACK
        public float MeleeCooldown { get => meleeCooldown; }
        public float RangedCooldown { get => rangedCooldown; }
        public bool CanMeleeAttack { get => canMeleeAttack; set { canMeleeAttack = value; } }
        public bool CanRangedAttack { get => canRangedAttack; set { canRangedAttack = value; } }
        public bool Aiming { get => aiming; set { aiming = value; } }

        // IN GAME REFS
        public Transform Cam { get => cam; set { cam = value; } }
        public GameObject Player { get => player; set { player = value; } }
        public CharacterController Controller { get => controller; set { controller = value; } }
        public Animator Anim { get => anim; set { anim = value; } }
        public GameObject ActiveSword { get => activeSword; set { activeSword = value; } }
        public GameObject InactiveSword { get => inactiveSword; set { inactiveSword = value; } }
        public GameObject ActiveBow { get => activeBow; set { activeBow = value; } }
        public GameObject InactiveBow { get => inactiveBow; set { inactiveBow = value; } }
    }
}