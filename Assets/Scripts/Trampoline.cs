using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] float jumpForce;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D playerCollision)
    {
        if (playerCollision.gameObject.tag == "Player")
        {
            Vector2 vector = new Vector2(0f, jumpForce);
            animator.SetTrigger("Jump");
            playerCollision.gameObject.GetComponent<Rigidbody2D>().AddForce(vector, ForceMode2D.Impulse);
        }

    }
}
