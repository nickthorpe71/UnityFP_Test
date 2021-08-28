using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using Actions;

public class Game : MonoBehaviour 
{
    // DATA
    private PlayerData playerData = new PlayerData();
    private EnvironmentPhysicsData envPhysicsData = new EnvironmentPhysicsData();

    // PLAYER REFERENCES
    public Transform playerCam;
    public GameObject player;
    public CharacterController playerController;
    public Animator playerAnimator;

    // ENVIRONMENT PHYSICS REFERENCES
    [SerializeField] private LayerMask groundMask;
    
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() 
    {
        PlayerActions.HandlePlayerInput(
            player.transform,
            playerData,
            playerCam.eulerAngles.y,
            envPhysicsData.Gravity,
            playerAnimator,
            StartRoutine
        );

        EnvironmentPhysicsActions.UpdateGravity(
            player.transform,
            playerData,
            envPhysicsData.Gravity,
            envPhysicsData.GroundCheckDistance,
            groundMask
        );

        PlayerActions.UpdatePlayerVelocity(
            playerController,
            playerData
        );

        UpdatePlayerMoveAnimation(playerData);
    }

    public void StartRoutine(IEnumerator routine)
    {
        StartCoroutine(routine);
    }

    private void UpdatePlayerMoveAnimation(PlayerData playerData) 
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
