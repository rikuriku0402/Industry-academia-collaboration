using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    float jumpForce = 390.0f;       // ジャンプ時に加える力
    float jumpThreshold = 2.0f;    // ジャンプ中か判定するための閾値
    float runForce = 30.0f;       // 走り始めに加える力
    float runSpeed = 0.5f;       // 走っている間の速度
    float runThreshold = 2.0f;   // 速度切り替え判定のための閾値
    bool isGround = true;        // 地面と接地しているか管理するフラグ
    int key = 0;                 // 左右の入力管理


    string state;                // プレイヤーの状態管理
    string prevState;            // 前の状態を保存
    float stateEffect = 1;       // 状態に応じて横移動速度を変えるための係数


    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
        GetInputKey();          // ① 入力を取得
        //ChangeState();          // ② 状態を変更する
        //ChangeAnimation();      // ③ 状態に応じてアニメーションを変更する
        Move();                 // ④ 入力に応じて移動する
    }

    void GetInputKey()
    {
        key = 0;
        if (Input.GetKey(KeyCode.RightArrow))
            key = 1;
        if (Input.GetKey(KeyCode.LeftArrow))
            key = -1;
    }

    //void ChangeState()
    //{
    //    // 空中にいるかどうかの判定。上下の速度(rigidbody.velocity)が一定の値を超えている場合、空中とみなす
    //    if (Mathf.Abs(rb.velocity.y) > jumpThreshold)
    //    {
    //        isGround = false;
    //    }

    //    // 接地している場合
    //    if (isGround)
    //    {
    //        // 走行中
    //        if (key != 0)
    //        {
    //            state = "RUN";
    //            //待機状態
    //        }
    //        else
    //        {
    //            state = "IDLE";
    //        }
    //        // 空中にいる場合
    //    }
    //    else
    //    {
    //        // 上昇中
    //        if (rb.velocity.y > 0)
    //        {
    //            state = "JUMP";
    //            // 下降中
    //        }
    //        else if (rb.velocity.y < 0)
    //        {
    //            state = "FALL";
    //        }
    //    }
    //}

    //void ChangeAnimation()
    //{
    //    // 状態が変わった場合のみアニメーションを変更する
    //    if (prevState != state)
    //    {
    //        switch (state)
    //        {
    //            case "JUMP":
    //                animator.SetBool("JumpUp", true);
    //                animator.SetBool("JumpDown", false);
    //                animator.SetBool("Run", false);
    //                animator.SetBool("Idle", false);
    //                stateEffect = 0.5f;
    //                break;
    //            case "FALL":
    //                animator.SetBool("JumpDown", true);
    //                animator.SetBool("JumpUp", false);
    //                animator.SetBool("Run", false);
    //                animator.SetBool("Idle", false);
    //                stateEffect = 0.5f;
    //                break;
    //            case "RUN":
    //                animator.SetBool("Run", true);
    //                animator.SetBool("JumpDown", false);
    //                animator.SetBool("JumpUp", false);
    //                animator.SetBool("Idle", false);
    //                stateEffect = 1f;
    //                transform.localScale = new Vector3(key, 1, 1); // 向きに応じてキャラクターを反転
    //                break;
    //            default:
    //                animator.SetBool("Idle", true);
    //                animator.SetBool("JumpDown", false);
    //                animator.SetBool("Run", false);
    //                animator.SetBool("JumpUp", false);
    //                stateEffect = 1f;
    //                break;
    //        }
    //        // 状態の変更を判定するために状態を保存しておく
    //        prevState = state;
    //    }
    //}

    void Move()
    {
        // 接地している時にSpaceキー押下でジャンプ
        if (isGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.rb.AddForce(transform.up * this.jumpForce);
                isGround = false;
            }
        }

        // 左右の移動。一定の速度に達するまではAddforceで力を加え、それ以降はtransform.positionを直接書き換えて同一速度で移動する
        float speedX = Mathf.Abs(this.rb.velocity.x);
        if (speedX < this.runThreshold)
        {
            this.rb.AddForce(transform.right * key * this.runForce * stateEffect); //未入力の場合は key の値が0になるため移動しない
        }
        else
        {
            this.transform.position += new Vector3(runSpeed * Time.deltaTime * key * stateEffect, 0, 0);
        }

    }

    //着地判定
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            if (!isGround)
                isGround = true;
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            if (!isGround)
                isGround = true;
        }
    }

}
