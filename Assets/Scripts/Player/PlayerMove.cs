using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    Transform tr;
    SpriteRenderer sprRen;
    Animator animator;
    Rigidbody2D rigid;

    public float RunSpeed = 1.0f;
    public float jumpScale = 5.0f;
    bool possibleJump = true;

    void Awake()
    {
        tr = GetComponent<Transform>();
        sprRen = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float runDir = Input.GetAxisRaw("Horizontal");
        if(runDir != 0)
        {
            animator.SetBool("IsRun", true);
            Run(runDir);
        } else
        {
            animator.SetBool("IsRun", false);
        }

        if (possibleJump)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                animator.SetBool("IsJump", true);
                Jump();
            }
        }

        if (rigid.velocity.y == 0)
        {
            animator.SetBool("IsJump", false);
            possibleJump = true;
        }
    }

    void Run(float runDir)
    {
        tr.Translate(new Vector2(runDir * RunSpeed, 0));

        if (runDir < 0)
        {
            sprRen.flipX = true;
        }
        else if (runDir > 0)
        {
            sprRen.flipX = false;
        }
    }

    void Jump()
    {
        possibleJump = false;
        Vector2 jumpDir = new Vector2(0, jumpScale);
        rigid.AddForce(jumpDir, ForceMode2D.Impulse);
    }
}
