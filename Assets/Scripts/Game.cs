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

    // ENVIRONMENT PHYSICS REFERENCES
    [SerializeField] private LayerMask groundMask;
    
    private void Awake() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {

        PlayerActions.HandlePlayerInput(
            player.transform,
            playerData,
            playerCam.eulerAngles.y,
            envPhysicsData.Gravity
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
    }

}
