using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] float jumpPower = 700f;

    private PlayerWalk playerWalk;
    private Rigidbody2D rb;

    //private penguinAnim penguinanim;
    private Animator anim = null;

    private bool isGround = false;
    private bool isJump;
    private void Start()
    {
        // このスクリプトと同じゲームオブジェクトにアタッチされている、
        // PlayerWalk スクリプトのコンポーネントを取得する
        playerWalk = GetComponent<PlayerWalk>();
        rb = GetComponent<Rigidbody2D>();
        //penguinanim = GetComponent<penguinAnim>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        anim.SetBool("Ground", isGround);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("Jump",isJump);
            //anim.Play("1penguin＿_Jump");

            // 接地しているときのみ、ジャンプできる（多段ジャンプをさせない）
            if (playerWalk.isGround)
            {
                rb.AddForce(Vector2.up * jumpPower);

            }
            else
            {
                isJump = false;
                //anim.SetBool("Jump", false);
            }
        }
        float speedx = Mathf.Abs(this.rb.velocity.x);

        if (this.rb.velocity.y == 0)
        {
            this.anim.speed = speedx = speedx / 2.0f;
        }
        else
        {
            this.anim.speed = 1.0f;
            anim.SetBool("Jump",isJump);
            anim.SetBool("Ground", isGround);
        }
    }
    private void AnimatePlayer()
    {
        //penguinanim.Running(isGround);
    }
}
