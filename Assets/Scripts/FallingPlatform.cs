using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallingTime;
    private BoxCollider2D collider;
    private TargetJoint2D target;
    private Animator animator;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        target = GetComponent<TargetJoint2D>();
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            Invoke("FallingObject", fallingTime);
        }
    }

    void FallingObject()
    {
        target.enabled = false;
        collider.isTrigger = true;
        animator.SetBool("isFlying", false);
    }
}
