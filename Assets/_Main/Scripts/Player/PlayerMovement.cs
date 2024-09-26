using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public bool isRun;
    [SerializeField] private Camera mainCamera;
    //set move
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private int rangeMove;
    [SerializeField] private float durationMove = 1f;
    //set input
    //[SerializeField] private int rangeSwape = 50;
    //set comp
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform transformPlayer;


    private Vector3 touchStartPos;
    private Vector3 touchDelta;
    //private float lastTouchTime;
    //private int touchCount = 0;
    private PlayerPosition currenPlayerPosition;
    private bool isSwaping = false;
    private bool isJump = false;


    private void Start()
    {
        currenPlayerPosition = PlayerPosition.MIDDLE;
    }


    void Update()
    {

        if (isRun)
        {
            rb.velocity = transform.forward * speed;
        }

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                isSwaping = true;
                touchStartPos = Input.GetTouch(0).position;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                ResetSwape();
            }

           
        }

        CheckSwape();
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log($"Input.GetKeyDown(KeyCode.A)");
            TryChangePositionPlayer(ActionMove.PlayerGoLeft);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log($"Input.GetKeyDown(KeyCode.D)");
            TryChangePositionPlayer(ActionMove.PlayerGoRight);
        }
    }
    private void CheckSwape()
    {
        touchDelta = Vector3.zero;

        if (isSwaping)
        {
            if (Input.touchCount > 0)
            {
                Vector3 touchPosition3D = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0);
                touchDelta = touchPosition3D - touchStartPos;
            }
        }
        // left move
        if (touchDelta.x < -50)
        {
            //rb.AddForce(-mainCamera.transform.right * speed, ForceMode.VelocityChange);
            TryChangePositionPlayer(ActionMove.PlayerGoLeft);
            ResetSwape();
        }
        //right move
        if (touchDelta.x > 50)
        {
            //rb.AddForce(mainCamera.transform.right * speed, ForceMode.VelocityChange);
            TryChangePositionPlayer(ActionMove.PlayerGoRight);
            ResetSwape();
        }
        //jump
        if (touchDelta.y > 50 && !isJump)
        {
            //rb.AddForce(mainCamera.transform.right * speed, ForceMode.VelocityChange);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJump = true;
            ResetSwape();
        }
    }
    private void ResetSwape()
    {
        isSwaping = false;
        touchStartPos = Vector3.zero;
        touchDelta = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }
    private bool TryChangePositionPlayer(ActionMove directMove)
    {
        bool isMove = false;
        //left move
        if (directMove == ActionMove.PlayerGoLeft && !(currenPlayerPosition == PlayerPosition.LEFT) && !isMove)
        {       
            MoveToNewPosition(-rangeMove);
            if(currenPlayerPosition == PlayerPosition.MIDDLE)
            {
                currenPlayerPosition = PlayerPosition.LEFT;
            }
            if (currenPlayerPosition == PlayerPosition.RIGHT)
            {
                currenPlayerPosition = PlayerPosition.MIDDLE;
            }
            isMove = true;
            Debug.Log($"left move current pos={currenPlayerPosition}");

            return true;
        }
        //right move
        if (directMove == ActionMove.PlayerGoRight && !(currenPlayerPosition == PlayerPosition.RIGHT) && !isMove)
        {
            MoveToNewPosition(rangeMove);
            if (currenPlayerPosition == PlayerPosition.MIDDLE)
            {
                currenPlayerPosition = PlayerPosition.RIGHT;
            }
            if (currenPlayerPosition == PlayerPosition.LEFT)
            {
                currenPlayerPosition = PlayerPosition.MIDDLE;
            }
            isMove = true;
            Debug.Log($"right move current pos={currenPlayerPosition}");

            return true;
        }
        else
        {
            Debug.Log("False move");
            return false;
        }
    }

    public void MoveToNewPosition(int deltaX)
    {
        transformPlayer.DOMove(CalculateTargetPositionX(transformPlayer, deltaX), durationMove);
    }

    public Vector3 CalculateTargetPositionX(Transform currentPosition, int deltaX)
    {
        Vector3 targetPos = new Vector3(currentPosition.position.x + deltaX, currentPosition.position.y, currentPosition.position.z);
        Debug.Log("TargetPosition: " + targetPos);
        return targetPos;
    }
}

public enum PlayerPosition
{
    LEFT,
    MIDDLE,
    RIGHT
}

public enum ActionMove
{
    PlayerGoLeft,
    PlayerGoRight
}