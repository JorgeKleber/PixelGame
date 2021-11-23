using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float JumpForce;
    [SerializeField] bool doubleJump;
    private Rigidbody2D rigidbody;
    private Animator animator;
    private bool isJump;
    private bool isRunning;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        if (Input.GetAxis("Horizontal") > 0f)
        {
            animator.SetBool("isRunning", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (Input.GetAxis("Horizontal") < 0f)
        {
            animator.SetBool("isRunning", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (Input.GetAxis("Horizontal") == 0f)
        {
            animator.SetBool("isRunning", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isJump == false)
            {
                rigidbody.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                animator.SetBool("isJump", true);
            }
            else
            {
                if (doubleJump == true)
                {
                    rigidbody.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D player)
    {
        if (player.gameObject.layer == 3)
        {
            isJump = false;
            animator.SetBool("isJump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D player)
    {
        if (player.gameObject.layer == 3)
        {
            isJump = true;
        }
    }
}
