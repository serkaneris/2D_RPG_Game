using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.5f;

    private Vector2 movement;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        TakeInput();
        Move();
    }

    private void TakeInput()
    {
        movement = Vector2.zero;

        if(Input.GetKey(KeyCode.W))
        {
            movement += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector2.right;
        }
    }

    private void Move()
    {
        transform.Translate(movement * speed * Time.deltaTime);
        SetAnimatorMovement(movement);
    }

    private void SetAnimatorMovement(Vector2 direction)
    {
        if(direction.x !=0 || direction.y != 0)
        {
            //animator.SetFloat("xDir", direction.x);
            //animator.SetFloat("yDir", direction.y);

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Magnitude", movement.magnitude);

            //animator.SetLayerWeight(1, 1);
        }
        else
        {
            //animator.SetLayerWeight(1, 0);
        }
    }
}
