using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerMovementCC : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private int multiGravity = 3;
    [SerializeField] private float jumpSpeed = 10;
    [SerializeField] private float speed = 0.2f;

    private float sumVectorY;
    private float sumVectorX;

    [SerializeField] private float laneSpeedChange = 2f;
    [SerializeField] private float laneWidth = 10f;
    [SerializeField,ReadOnly] private int currentLane = 1; // Текущая полоса (0 - левая, 1 - середина, 2 - правая)

    private bool isMoving;

    private void Update()
    {
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");

        //if (characterController.isGrounded)
        //{
        //    sumVectorY = 0;
        //    if (Input.GetKeyDown(KeyCode.W))
        //    {
        //        sumVectorY = jumpSpeed;
        //    }
        //}
        //sumVectorY += gravity * Time.deltaTime * multiGravity;

        //Vector3 direction = new Vector3(h * speed, sumVectorY * Time.deltaTime, 1 * speed);
        //characterController.Move(direction);

        // Обработка ввода
        if (Input.GetKeyDown(KeyCode.A) && currentLane >= 1)
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.D) && currentLane < 2)
        {
            MoveRight();
        }

        // Прыжок
        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            sumVectorY = jumpSpeed;
        }

        // Гравитация
        sumVectorY += gravity * Time.deltaTime * multiGravity;

        // Движение вперед
        Vector3 direction = new Vector3(sumVectorX, sumVectorY * Time.deltaTime, 1 * speed);
        characterController.Move(direction);

        CheckStopMove();
    }


    private void MoveLeft()
    {
        if (isMoving)
            return;  

             
        currentLane--;
        sumVectorX = -laneSpeedChange;
        isMoving = true;
        //transform.position = new Vector3(transform.position.x - laneWidth, transform.position.y, transform.position.z);
        Debug.Log("MoveLeft");
    }

    // Движение вправо
    private void MoveRight()
    {
        if (isMoving)
            return;
        Debug.Log("MoveRight");
        currentLane++;
        sumVectorX = laneSpeedChange;
        isMoving = true;
        //transform.position = new Vector3(transform.position.x + laneWidth, transform.position.y, transform.position.z);
    }

    private void CheckStopMove()
    {
        if (isMoving)
        {
            if (currentLane == 0 && transform.position.x <= 0f)
            {
                sumVectorX = 0f;
                isMoving = false;
            }
            else if (currentLane == 1 && Mathf.Abs(transform.position.x) <= 0.1f)
            {
                sumVectorX = 0f;
                isMoving = false;
            }
            else if (currentLane == 2 && transform.position.x >= laneWidth)
            {
                sumVectorX = 0f;
                isMoving = false;
            }
        }
    }
}
