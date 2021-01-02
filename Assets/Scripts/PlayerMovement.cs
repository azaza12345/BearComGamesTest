using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float moveSpeed;
    [Header("Jump")]
    [SerializeField] float jumpForce;
    [SerializeField] Transform playerFeet;
    [SerializeField] float checkRadius;
    private Animator myAnimator;
    private Rigidbody myRigidbody;
    private float moveInput;
    private bool isGrounded;
    private float verticalMove;
    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Moving();
        Jump();
        Flip();
    }

    private void Moving()
    {
        moveInput = joystick.Horizontal;
        myRigidbody.velocity = new Vector3(moveInput * moveSpeed, myRigidbody.velocity.y, 0);

        myAnimator.SetBool("Running", GetPlayerHasHorizontalSpeed());
    }

    private void Jump()
    {
        verticalMove = joystick.Vertical;
        if(isGrounded == true && verticalMove >= 0.5f)
        {
            myRigidbody.velocity = Vector2.up * jumpForce;
            myAnimator.SetTrigger("Jump");
        }

    }

    private void Flip()
    {
        if (GetPlayerHasHorizontalSpeed())
        {
            transform.localScale = new Vector2(Mathf.Sign(-myRigidbody.velocity.x), 1f);
        }
    }

    private bool GetPlayerHasHorizontalSpeed()
    {
        return Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Ground")
            isGrounded = true;
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
            isGrounded = false;
    }

}
