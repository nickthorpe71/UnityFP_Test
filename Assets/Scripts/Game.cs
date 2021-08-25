using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using Actions;

public class Game : MonoBehaviour 
{
    // DATA
    private PlayerData playerData = new PlayerData(7f, 13f, 0.025f);
    private EnvironmentPhysicsData envPhysicsData = new EnvironmentPhysicsData(-9.81f, 0.2f);

    // PLAYER REFERENCES
    public Transform playerCam;
    public GameObject player;
    public CharacterController playerController;

    // ENVIRONMENT PHYSICS REFERENCES
    [SerializeField] private LayerMask groundMask;
    

    private void Update() {

        PlayerActions.HandlePlayerInput(
            player.transform,
            playerData,
            playerCam.eulerAngles.y
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
