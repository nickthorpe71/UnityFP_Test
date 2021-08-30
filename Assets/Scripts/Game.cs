using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using Actions;

using System;
using Cinemachine;

public class Game : MonoBehaviour 
{
    // REFACTOR
    [SerializeField] private CinemachineFreeLook freeCam;
    private float zoomSpeed = 5f;
    private float zoomAcceleration = 2.5f;
    private float zoomInnerRange = 3f;
    private float zoomOuterRange = 30f;
    private float currentMiddleRigRadius = 10f;
    private float newMiddleRigRadius = 10f;

    private float zoomYAxis = 0f;
    public float ZoomYAxis
    {
        get => zoomYAxis;
        set
        {
            if (zoomYAxis == value) return;
            zoomYAxis = value;
            AdjustCameraZoomIndex(ZoomYAxis);
        }
    }


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
            player.transform, // TODO: can be pulled from player data
            playerData,
            envPhysicsData.Gravity,
            envPhysicsData.GroundCheckDistance,
            groundMask
        );

        PlayerActions.UpdatePlayerVelocity(
            playerController,
            playerData
        );

        PlayerActions.UpdatePlayerCam(playerData);

        PlayerAnimation.Animate(playerAnimator, playerData);

        // REFACTOR
        ZoomYAxis = Input.GetAxis("Mouse ScrollWheel");   
    }

    // REFACTOR
    private void LateUpdate() 
    {
        UpdateZoomLevel();
    }

    private void UpdateZoomLevel()
    {
        if (currentMiddleRigRadius == newMiddleRigRadius) return;

        currentMiddleRigRadius = Mathf.Lerp(currentMiddleRigRadius, newMiddleRigRadius, zoomAcceleration * Time.deltaTime);
        currentMiddleRigRadius = Mathf.Clamp(currentMiddleRigRadius, zoomInnerRange, zoomOuterRange);

        freeCam.m_Orbits[1].m_Radius = currentMiddleRigRadius;
        freeCam.m_Orbits[0].m_Height = freeCam.m_Orbits[1].m_Radius;
        freeCam.m_Orbits[2].m_Height = freeCam.m_Orbits[1].m_Radius;
    }

    private void AdjustCameraZoomIndex(float zoomYAxis)
    {
        if (zoomYAxis == 0) return;

        newMiddleRigRadius = currentMiddleRigRadius + (zoomYAxis < 0 ? zoomSpeed : -zoomSpeed);
    }

    public void StartRoutine(IEnumerator routine)
    {
        StartCoroutine(routine);
    }


}
