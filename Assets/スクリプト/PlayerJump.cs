using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] float jumpPower = 700f;

    private PlayerWalk playerWalk;
    private Rigidbody2D rb;
    private Animator anim; 

    private void Start()
    {
        // このスクリプトと同じゲームオブジェクトにアタッチされている、
        // PlayerWalk スクリプトのコンポーネントを取得する
        playerWalk = GetComponent<PlayerWalk>();

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 接地しているときのみ、ジャンプできる（多段ジャンプをさせない）
            if (playerWalk.isGround)
            {
                rb.AddForce(Vector2.up * jumpPower);
                anim.SetBool("Cat Run", true);
            }
        }
    }
}
