using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] Vector2 Speed;
    [SerializeField] float JumpForce;
    [SerializeField] bool doubleJump;
    [SerializeField] GameObject gameOverScreem;
    private Rigidbody2D rigidbody;
    private Animator playerAnimator;
    private bool isJump;
    private bool isRunning;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), 0f);
        //transform.position += movement * Time.deltaTime * Speed;

        if(Input.GetAxis("Horizontal") != 0)
        {
            rigidbody.MovePosition(rigidbody.position + Speed * Time.fixedDeltaTime);
        }

        if (Input.GetAxis("Horizontal") > 0f)
        {
            playerAnimator.SetBool("isRunning", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (Input.GetAxis("Horizontal") < 0f)
        {
            playerAnimator.SetBool("isRunning", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (Input.GetAxis("Horizontal") == 0f)
        {
            playerAnimator.SetBool("isRunning", false);
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
                playerAnimator.SetBool("isJump", true);
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
            playerAnimator.SetBool("isJump", false);
        }

        if (player.gameObject.layer == 8)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            gameOverScreem.SetActive(true);
            Destroy(this);

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
