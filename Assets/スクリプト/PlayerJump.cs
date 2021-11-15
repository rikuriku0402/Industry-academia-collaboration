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

    private bool isGround;
    private void Start()
    {
        // このスクリプトと同じゲームオブジェクトにアタッチされている、
        // PlayerWalk スクリプトのコンポーネントを取得する
        playerWalk = GetComponent<PlayerWalk>();
        rb = GetComponent<Rigidbody2D>();
        //penguinanim = GetComponent<penguinAnim>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("Jump",true);
            //anim.Play("1penguin＿_Jump");

            // 接地しているときのみ、ジャンプできる（多段ジャンプをさせない）
            if (playerWalk.isGround)
            {
                rb.AddForce(Vector2.up * jumpPower);

            }
            else
            {
                anim.SetBool("Jump", false);
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
        }
    }
    private void AnimatePlayer()
    {
        //penguinanim.Running(isGround);
    }
}
