﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    up, upleft, left, downleft, down, downright, right, upright
}

public class PlayerMovement : MonoBehaviour
{
    public static float speed = 5f;
    public static Vector2 movement;
    public Vector3 mousePosition;


    void Start()
    {
        Screen.fullScreen = true;
        //Cursor.visible = false;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        SetDirection();
    }

    private void FixedUpdate()
    {
        // Adjust for diagonal input 
        if (movement.magnitude > 1f)
        {
            movement /= movement.magnitude;
        }

        //// Reverse direction of vector 
        //Vector3 headDirection = mousePosition - transform.position;

        //// Angle between x axis and directional vector (x,y)
        //float zAngle = Mathf.Atan2(headDirection.y, headDirection.x) * Mathf.Rad2Deg + -90f; // +/- 90f 

        //transform.rotation = Quaternion.Euler(0f, 0f, zAngle);

        Vector3 velocity = new Vector3(movement.x, movement.y, 0f);
        transform.position += velocity * speed * Time.fixedDeltaTime;
    }

    private void SetDirection()
    {
        if (movement == Vector2.up)
        {
            SpriteAnimator.direction = Direction.up;
        }
        else if (movement == new Vector2(-1f, 1f))
        {
            SpriteAnimator.direction = Direction.upleft;
        }
        else if (movement == Vector2.left)
        {
            SpriteAnimator.direction = Direction.left;
        }
        else if (movement == new Vector2(-1f, -1f))
        {
            SpriteAnimator.direction = Direction.downleft;
        }
        else if (movement == Vector2.down)
        {
            SpriteAnimator.direction = Direction.down;
        }
        else if (movement == new Vector2(1f, -1f))
        {
            SpriteAnimator.direction = Direction.downright;
        }
        else if (movement == Vector2.right)
        {
            SpriteAnimator.direction = Direction.right;
        }
        else if (movement == Vector2.one)
        {
            SpriteAnimator.direction = Direction.upright;
        }
    }
}