using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Timeline.TimelineAsset;

public class PlayerMovementCC : MonoBehaviour //+ event input
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Transform PlayerPos;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private int multiGravity = 3;
    [SerializeField] private float jumpSpeed = 10;
    [SerializeField] private float speed = 0.2f;

    private float sumVectorY;
    private float sumVectorX;

    [SerializeField] private float laneSpeedChange = 2f;
    [SerializeField] private float laneWidth = 10f;
    [SerializeField,ReadOnly] private int currentLane = 1; // ������� ������ (0 - �����, 1 - ��������, 2 - ������)

    private bool isMoving;
    private Vector3 previousPosition;
    private int previousLane;


    private float zoneLeftX;
    private float zoneMiddleX;
    private float zoneRightX;

    


    private void Start()
    {
        zoneMiddleX = transform.position.x;

        zoneLeftX = zoneMiddleX - laneWidth;

        zoneRightX = zoneMiddleX + laneWidth;
    }



    private void Update()
    {
        // ��������� �����
        if (Input.GetKeyDown(KeyCode.A) && currentLane >= 1)
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.D) && currentLane < 2)
        {
            MoveRight();
        }

        // ������
        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            sumVectorY = jumpSpeed;
            Debug.Log("Jump");
        }

        // ����������
        sumVectorY += gravity * Time.deltaTime * multiGravity;

        // �������� ������
        Vector3 direction = new Vector3(sumVectorX, sumVectorY * Time.deltaTime, 1 * speed);
        characterController.Move(direction);
        if(sumVectorY < -10 || characterController.isGrounded)
        {
            sumVectorY = -0.001f;
        }

        CheckStopMove();
    }


    private void MoveLeft()
    {
        if (isMoving)
            return;

        previousPosition = PlayerPos.position;
        previousLane = currentLane;

        currentLane--;
        sumVectorX = -laneSpeedChange;
        isMoving = true;
        
        //Debug.Log("MoveLeft");
    }

    // �������� ������
    private void MoveRight()
    {
        if (isMoving)
            return;

        previousPosition = PlayerPos.position;
        previousLane = currentLane;

        //Debug.Log("MoveRight");
        currentLane++;
        sumVectorX = laneSpeedChange;
        isMoving = true;
        
    }

    private void CheckStopMove()
    {
        if (isMoving)
        {

            // midle -> left
            if (currentLane == 0 && transform.position.x <= zoneLeftX)
            {
                sumVectorX = 0f;
                isMoving = false;
            }
            //right -> midle
            else if (currentLane == 1 && Mathf.Abs(transform.position.x) <= zoneMiddleX && previousLane == 2)
            {
                sumVectorX = 0f;
                isMoving = false;
            }
            //left -> midle
            else if (currentLane == 1 && Mathf.Abs(transform.position.x) >= zoneMiddleX && previousLane == 0)
            {
                sumVectorX = 0f;
                isMoving = false;
            }
            // midle -> right
            else if (currentLane == 2 && transform.position.x >= zoneRightX)
            {
                sumVectorX = 0f;
                isMoving = false;

            }
        }
    }


    //Hit on object
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (isMoving && hit.gameObject.CompareTag("Obstacle")) 
        {

            PlayerPos.DOMove(previousPosition, 0.5f);

            currentLane = previousLane;

            sumVectorX = 0f;
            isMoving = false;
            
            Debug.Log("Obstacle hit");
        }
    }
}
