using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;


    public Animator animator;
    Vector2 movement;

    bool facingRight;

    bool canMove;





    private void Awake()
    {

        canMove = true;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
  
            //input
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

        if (canMove == true)
        {
            //animator
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }

        

    }

    private void FixedUpdate()
    {
        if (canMove == true)
        {
            //movement
            Direction();
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }

    }

    private void Direction()
    {
        //check direction
        if (movement.x > 0)
        {
            facingRight = true;
            animator.SetBool("facingRight", facingRight);
        }
        else
        {
            facingRight = false;
            animator.SetBool("facingRight", facingRight);
        }
    }

    public void setMove(bool status)
    {
        this.canMove = status;
    }
}
