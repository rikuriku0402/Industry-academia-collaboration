using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] float jumpPower = 700f;

    private PlayerWalk playerWalk;
    private Rigidbody2D rb;

    private void Start()
    {
        // このスクリプトと同じゲームオブジェクトにアタッチされている、
        // PlayerWalk スクリプトのコンポーネントを取得する
        playerWalk = GetComponent<PlayerWalk>();

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 接地しているときのみ、ジャンプできる（多段ジャンプをさせない）
            if (playerWalk.isGround)
            {
                rb.AddForce(Vector2.up * jumpPower);
            }
        }
    }
}
