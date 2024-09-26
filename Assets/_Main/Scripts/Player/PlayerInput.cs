using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //[SerializeField] private Camera mainCamera;
    [SerializeField] private int rangeSwape = 50;

    private Vector3 touchStartPos;
    private Vector3 touchDelta;
    private bool isSwaping = false;


    void Update()
    {
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
        if (touchDelta.x < -rangeSwape)
        {
            Debug.Log("left move SW");
            EventBus.RaiseEvent(new NewInputSwapeEvent(ActionInput.SwapeLeft));
            ResetSwape();
        }


        //right move
        if (touchDelta.x > rangeSwape)
        {
            Debug.Log("right move SW");
            EventBus.RaiseEvent(new NewInputSwapeEvent(ActionInput.SwapeRight));
            ResetSwape();
        }


        //jump
        if (touchDelta.y > rangeSwape)
        {          
            Debug.Log("UP move SW");
            EventBus.RaiseEvent(new NewInputSwapeEvent(ActionInput.SwapeUp));
            ResetSwape();
        }
    }
    private void ResetSwape()
    {
        isSwaping = false;
        touchStartPos = Vector3.zero;
        touchDelta = Vector3.zero;
    }


    
}
public enum ActionInput
{
    SwapeLeft,
    SwapeRight,
    SwapeUp,
    Tap
}
