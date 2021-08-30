using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using Actions;

public class Game : MonoBehaviour 
{
    // PLAYER REFERENCES
    [SerializeField] private Transform playerCam;
    [SerializeField] private GameObject player;
    [SerializeField] private CharacterController playerController;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private GameObject activeSword;
    [SerializeField] private GameObject inactiveSword;
    [SerializeField] private GameObject activeBow;
    [SerializeField] private GameObject inactiveBow;

    // ENVIRONMENT PHYSICS REFERENCES
    [SerializeField] private LayerMask groundMask;

    // DATA
    private PlayerData playerData;
    private EnvironmentPhysicsData envPhysicsData = new EnvironmentPhysicsData();
    
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        // Set Player Data
        playerData = new PlayerData(
        playerCam,
        player,
        playerController,
        playerAnimator,
        activeSword,
        inactiveSword,
        activeBow,
        inactiveBow);
    }

    private void Update() 
    {
        PlayerActions.HandlePlayerInput(playerData, envPhysicsData.Gravity, StartRoutine);

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

        PlayerAnimation.Animate(playerAnimator, playerData);
    }

    public void StartRoutine(IEnumerator routine)
    {
        StartCoroutine(routine);
    }
}
