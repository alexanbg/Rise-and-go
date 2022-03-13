using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float distance;


    private Vector3 playerPosition;
    private Camera mainCamera;
    private Transform cameraTransform;

    private float width;
    private float height;

    private void Awake()
    {
        cameraTransform = GetComponent<Transform>();
        mainCamera = GetComponent<Camera>();
        height = mainCamera.orthographicSize * 2f;
        width = height * mainCamera.aspect;
    }

    private void Update()
    {
        playerPosition = Camera.main.WorldToViewportPoint(player.position);

        if (playerPosition.x > 1)
        {
            //move right
            cameraTransform.position += new Vector3(width, 0, 0);
        }
        if (playerPosition.x < 0)
        {
            //move left
            cameraTransform.position -= new Vector3(width, 0, 0);
        }
        if (playerPosition.y > 1)
        {
            //move up
            cameraTransform.position += new Vector3(0, height, 0);
        }
        if (playerPosition.y < 0)
        {
            //move down
            cameraTransform.position -= new Vector3(0, height, 0);
        }
    }




}
