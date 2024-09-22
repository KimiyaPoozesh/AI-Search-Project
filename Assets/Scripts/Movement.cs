using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveDistance = 1.6f;  // Distance to move in each direction
    public float moveSpeed = 2f;  // Speed of movement
    private Vector3 targetPosition;  // Target position of the object
    private bool isMoving = false;  // Track if movement is happening

    private void Update()
    {
        // If the object is moving, smoothly move it towards the target position
        if (isMoving)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);

            // Stop movement when the target position is reached
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                isMoving = false;
            }
        }
    }
    [ContextMenu(nameof(MoveUp))]

    // Function to move the object up (along the x-axis)
    public void MoveUp()
    {
        if (!isMoving)
        {
            // Move up along the x-axis (positive x direction)
            targetPosition = transform.position + new Vector3(moveDistance, 0, 0);
            isMoving = true;
        }
    }

    // Function to move the object down (along the x-axis)
    [ContextMenu(nameof(MoveDown))]
    public void MoveDown()
    {
        if (!isMoving)
        {
            // Move down along the x-axis (negative x direction)
            targetPosition = transform.position + new Vector3(-moveDistance, 0, 0);
            isMoving = true;
        }
    }

    // Function to move the object right (along the z-axis)
    [ContextMenu(nameof(MoveRight))]
    public void MoveRight()
    {
        if (!isMoving)
        {
            // Move right along the z-axis (positive z direction)
            targetPosition = transform.position + new Vector3(0, 0, moveDistance);
            isMoving = true;
        }
    }
    [ContextMenu(nameof(MoveLeft))]
    
    

    // Function to move the object left (along the z-axis)
    public void MoveLeft()
    {
        if (!isMoving)
        {
            // Move left along the z-axis (negative z direction)
            targetPosition = transform.position + new Vector3(0, 0, -moveDistance);
            isMoving = true;
        }
    }
}
