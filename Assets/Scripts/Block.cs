using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int id;                     
    public float moveDistance = 1.6f;   
    private float moveSpeed = 0.5f;        
    private float smoothing = 0.5f;       
    private Vector3 velocity = Vector3.zero;  
    private Vector3 targetPosition;      
    private bool isMoving = false;       
    private Vector3 initialPosition;  
    private void Start()
    {
        initialPosition = transform.position;
        targetPosition = transform.position; 
    }

    private void Update()
    {
        if (isMoving)
        {
           
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothing);

            
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition;  
                isMoving = false;
            }
        }
    }
    
    [ContextMenu(nameof(ResetPosition))]
    public void ResetPosition()
    {
        transform.position = initialPosition; 
        targetPosition = initialPosition;     
        isMoving = false;                     
    }

    [ContextMenu(nameof(MoveUp))]
    public void MoveUp()
    {
        if (!isMoving)
        {
            targetPosition = transform.position + new Vector3(moveDistance, 0, 0); 
            isMoving = true;
        }
    }

    [ContextMenu(nameof(MoveDown))]
    public void MoveDown()
    {
        if (!isMoving)
        {
            targetPosition = transform.position + new Vector3(-moveDistance, 0, 0);  
            isMoving = true;
        }
    }

    [ContextMenu(nameof(MoveRight))]
    public void MoveRight()
    {
        if (!isMoving)
        {
            targetPosition = transform.position + new Vector3(0, 0, -moveDistance); 
            isMoving = true;
            
        }
    }

    [ContextMenu(nameof(MoveLeft))]
    public void MoveLeft()
    {
        if (!isMoving)
        {
            targetPosition = transform.position + new Vector3(0, 0, moveDistance); 
            isMoving = true;
            
        }
    }
}
