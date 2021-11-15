using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    // 値はインスペクターから変更可能
    [SerializeField] float moveSpeed = 1000f;
    
    public bool isGround;

    private Rigidbody2D rb;
    private Vector3 defalutScale;

    [SerializeField]
    Animator anim;

    //private Animator anim = null;
    
        private void Start()
        {

        anim = GetComponent<Animator>();
            // ゲームプレイ中、頻繁に呼び出されるコンポーネントは Start 内でキャッシュしておく
            // 毎回 GetComponent すると負荷が高くなるため    
        rb = GetComponent<Rigidbody2D>();

            // 開始時のローカルスケールの値を記憶しておく
        defalutScale = transform.localScale;
        }
    private void FixedUpdate()
    {
        anim.SetBool("Ground", isGround);
    }
    private void Update()
    {
        
        //anim.Play("1penguin＿_Jump");
        // 左右方向の入力を受け取る
        float horizontalKey = Input.GetAxis("Horizontal");

        
        if(horizontalKey > 0)
        {
            anim.SetBool("Run", true);
        }
        else if (horizontalKey < 0)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

    }

        // 水平方向の移動
        private void Walk(float inputValue)
        {
            if (inputValue != 0)
            {
                // 接地していないときは水平方向に移動する力を弱める
                var mult = isGround ? 1f : 0.3f;

                // Rigidbody2D に力を加えることでプレイヤーキャラクターを移動させる
                rb.AddForce(Vector2.right * inputValue * moveSpeed * mult * Time.deltaTime);
            }
        }

    // 接地判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
    }
}
