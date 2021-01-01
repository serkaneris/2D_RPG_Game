using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    private bool isWalking;
    private float x, y;
    public float moveSpeed;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");


        if(x!=0 || y!=0)
        {
            if (!isWalking)
            {
                isWalking = true;
                animator.SetBool("IsWalking", isWalking);
               
            }
            Move();
        }
        else
        {
            if(isWalking)
            {
                isWalking = false;
                animator.SetBool("IsWalking", isWalking);
            }
        }

        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Magnitude", movement.m

        //if (movement.x  > 0 || movement.y > 0)
        //{
        //    animator.SetBool("IsWalking", true);
        //    animator.SetFloat("Horizontal", movement.x);
        //    animator.SetFloat("Vertical", movement.y);
        //    //animator.SetFloat("Magnitude", movement.magnitude);
        //}

        //else
        //{
        //    animator.SetBool("IsWalking", false);
        //    animator.SetFloat("Horizontal", movement.x);
        //    animator.SetFloat("Vertical", movement.y);
        //}


        //transform.position = transform.position + movement * Time.deltaTime;
    }

    private void Move()
    {
        animator.SetFloat("Horizontal", x);
        animator.SetFloat("Vertical", y);
        transform.Translate(x * Time.deltaTime * moveSpeed, y * Time.deltaTime * moveSpeed, 0f);
    }
}
