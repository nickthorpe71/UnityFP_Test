using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using static Calculations.MoveCalc;

public class Game : MonoBehaviour
{
    // REFERENCES
    public Transform playerCam;
    public GameObject player;
    public CharacterController playerController;

    // DATA
    private PlayerData playerData = new PlayerData(7f, 11f, 0.025f);
    
    private void Update()
    {
        HandlePlayerInput();
    }

    private void HandlePlayerInput()
    {
        HandleDirectionalInput(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void HandleDirectionalInput(float horizontal, float vertical)
    {
        Vector3 direction = CalcInputDirection(horizontal, 0f, vertical);

        // If the player has input movement
        if (direction.magnitude >= 0.1) 
        {
            bool isSprinting = Input.GetKey(KeyCode.LeftShift);
            float speed = HandleSprintInput(isSprinting);
            ExecuteDirectionalMovement(direction, speed);
        }
        else
        {
            ExecuteIdle();
        }
    }

    private float HandleSprintInput(bool isSprinting) => 
        isSprinting ? playerData.RunSpeed : playerData.WalkSpeed;

    private void ExecuteDirectionalMovement(Vector3 direction, float speed)
    {
        float targetAngle = CalcTargetAngleRelativeToCamera(direction, playerCam.eulerAngles.y);

        player.transform.rotation = CalcRotation(
            targetAngle,
            player.transform.eulerAngles.y,
            playerData.TurnSmoothTime
        );
        playerController.Move(CalcVelocity(CalcMoveDirection(targetAngle), speed));
    }

    private void ExecuteIdle()
    {

    }


    
}
