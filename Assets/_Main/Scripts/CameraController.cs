using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;
    [SerializeField] private float smothTime;

    private Vector3 offset;

    private Vector3 currentVelocity = Vector3.zero;


    private void Awake()
    {
        offset = transform.position - playerTransform.position;
    }

    private void LateUpdate()
    {
        Vector3 playerPosition = playerTransform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, playerPosition,ref currentVelocity, smothTime);
    }
}
