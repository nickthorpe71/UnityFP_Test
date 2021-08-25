using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using static Calculations.MoveCalc;

public class Game : MonoBehaviour
{
    public Transform playerCam;

    public GameObject player;
    public CharacterController playerController;

    private PlayerData playerData = new PlayerData(7.5f, 0.025f);
    
    private void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        DirectionalInput();
    }

    private void DirectionalInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        // If the player has input movement
        if (Mathf.Abs(horizontal) >= 0.1f || Mathf.Abs(vertical) >= 0.1f) 
        {
            Vector3 direction = CalcInputDirection(horizontal, 0f, vertical);
            float targetAngle = CalcTargetAngleRelativeToCamera(direction, playerCam.eulerAngles.y);

            player.transform.rotation = CalcRotation(targetAngle, player.transform.eulerAngles.y, playerData.TurnSmoothTime);
            playerController.Move(CalcVelocity(CalcMoveDirection(targetAngle), playerData.Speed));
        }
    }
}
