using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementCC : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private int multiGravity = 3;
    [SerializeField] private float jumpSpeed = 10;
    [SerializeField] private float speed = 0.2f;

    private float sumVectorY;



    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (characterController.isGrounded)
        {
            sumVectorY = 0;
            if (Input.GetKeyDown(KeyCode.W))
            {
                sumVectorY = jumpSpeed;
            }
        }
        sumVectorY += gravity * Time.deltaTime * multiGravity;

        Vector3 direction = new Vector3(h * speed, sumVectorY * Time.deltaTime, 1 * speed);
        characterController.Move(direction);
    }
}
