using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float Speed;
    [Header("重力")] public float gravity;
    [Header("ジャンプ速度")] public float jumpSpeed;
    [Header("ジャンプする高さ")] public float jumpHeight;
    [Header("ジャンプする制限時間")] public float jumpLimitTime;
    [Header("踏みつけ判定の高さの割合")] public float stepOnRate;
    [Header("ジャンプフォース")]public float jumpForce=200.0f;
    [Header("設置判定")] public GrouneCheck ground;
    [Header("頭をぶつけた判定")] public GrouneCheck head;
    [Header("ダッシュの速さ表現")] public AnimationCurve dashCurve;
    [Header("ジャンプの速さ表現")] public AnimationCurve jumpCurve;
    
    
    #endregion

    #region//プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private CapsuleCollider2D capcol = null;
    private SpriteRenderer sr = null;
    private bool isGround = false;
    private bool isHead = false;
    private bool isJump = false;
    private bool isRun = false;
    private bool isSibou = false;
    private bool isDown =false;
    private bool isOtherJump = false;
    private bool isContinue = false;
    private float continueTime = 0.0f;
    private float blinkTime=0.0f;
    private float jumpPos = 0.0f;
    private float otherJumpHeight = 0.0f;
    private float dashTime = 0.0f;
    private float beforKey = 0.0f;
    private float jumpTime = 0.0f;
    private string enemyTag = "Enemy";
    #endregion
    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        capcol = GetComponent<CapsuleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(isContinue)
        {
            //明滅　ついているときの戻る
            if (blinkTime > 0.2f)
            {
                sr.enabled = true;
                blinkTime = 0.0f;
            }
            //明滅　消えているとき
            else if (blinkTime > 0.1f)
            {
                sr.enabled = false;
            }
            //明滅　ついているとき
            else
            {
                sr.enabled = true;
            }
            //一秒経ったら明滅終わり
            if(continueTime>1.0f)
            {
                isContinue = false;
                blinkTime = 0.0f;
                continueTime = 0.0f;
                sr.enabled = true;
            }
            else
            {
                blinkTime += Time.deltaTime;
                continueTime += Time.deltaTime;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) &&
            this.rb.velocity.y == .0)
        {
            this.rb.AddForce(transform.up * this.jumpForce);
            
        }
        if(transform.position.y<-8)
        {
            SceneManager.LoadScene("ステージ１");
        }
    }

    void FixedUpdate()
    {
        if (!isSibou)
        {
            //接地判定を得る
            isGround = ground.IsGround();
            isHead = head.IsGround();

            //各種座標軸の速度を求める
            float xSpeed = GetXSpeed();
            float ySpeed = GetYSpeed();

            //アニメーションを適用
            SetAnimation();

            //移動速度を設定
            rb.velocity = new Vector2(xSpeed,ySpeed);
        }
        else
        {
            rb.velocity = new Vector2(0, -gravity);
        }
    }

    /// <summary>
    /// Y成分で必要な計算をし速度を返す
    /// </summary>
    /// <returns>Y軸の速さ</returns>
    private float GetYSpeed()
    {
        float verticalKey = Input.GetAxis("Vertical");
        float ySpeed = -gravity;

        
         //何かを踏んだ際のジャンプ
        if(isOtherJump)
        {
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + otherJumpHeight > transform.position.y;

            //ジャンプした時間が長くなりすぎていないか
            bool canTime = jumpLimitTime > jumpTime;

            if (canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isOtherJump = false;
                jumpTime = 0.0f;
            }
        }
          //地面にいるとき
        else if(isGround)
        {
            if (verticalKey > 0)
            {
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y;//ジャンプした位置を記録する
                isJump = true;
                jumpTime = 0.0f;
            }
            else
            {
                isJump = false;
            }
        }
        //ジャンプ中
        else if(isJump)
        {
            //上方向キーを押しているか
            bool pushUpKey = verticalKey > 0;
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if (pushUpKey && canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isJump = false;
                jumpTime = 0.0f;
            }
        }
         //アニメーションカーブを速度に適用
        if(isJump||isOtherJump)
        {
            ySpeed *= jumpCurve.Evaluate(jumpTime);
        }
        return ySpeed;
    }
    /// <summary>
    /// X成分で必要な計算をし、速度を返す
    /// </summary>
    /// <returns>X軸の速さ</returns>
    private float GetXSpeed()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;
        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isRun = true;
            dashTime += Time.deltaTime;
            xSpeed = -Speed;
        }
        else
        {
            isRun = false;
            xSpeed = 0.0f;
            dashTime = 0.0f;
        }
            //前回の入力ダッシュの反転を判断して速度を変える
            if (horizontalKey > 0 && beforKey < 0)
            {
                dashTime = 0.0f;
            }
            else if (horizontalKey < 0 && beforKey > 0)
            {
                dashTime = 0.0f;
            }
            beforKey = horizontalKey;
            xSpeed *= dashCurve.Evaluate(dashTime);
            beforKey = horizontalKey;
            return xSpeed;
        }
    
    /// <summary>
    /// アニメーションを設定する
    /// </summary>
    private void SetAnimation()
    {
        anim.SetBool("jump", isJump||isOtherJump);
        anim.SetBool("ground", isGround);
        anim.SetBool("run", isRun);
    }

    /// <summary>
    /// コンテニュー待機状態か
    /// </summary>
    /// <returns></returns>
    public bool IsContinueWaiting()
    {
        return IsDownAnimEnd();
    }
    //downアニメーションが完了しているかどうか
    private bool IsDownAnimEnd()
    {
        if(isDown&&anim!=null)
        {
            AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
            if(currentState.IsName("Cat sibou"))
            {
                if (currentState.normalizedTime >= 1)
                {
                    return true;
                }
            }
        }
        return false;
    }
    /// <summary>
    /// コンテニューする
    /// </summary>
    public void ContinuePlayer()
    {
        isDown = false;
        anim.Play("Cat Run");
        isJump = false;
        isOtherJump = false;
        isRun = false;
        isContinue = true;
    }
    #region//接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag==enemyTag)
        {
            //踏みつけ判定になる高さ
                float stepOnHeght = (capcol.size.y * (stepOnRate / 100f));
                //踏みつけ判定のワールド座標
                float judgePos = transform.position.y - (capcol.size.y / 2f) + stepOnHeght;

            foreach (ContactPoint2D p in collision.contacts)
            {
                if (p.point.y<judgePos)
                {
                    //もう一度跳ねる
                    ObjeCollsion o = collision.gameObject.GetComponent<ObjeCollsion>();
                    if(o !=null)
                    {
                        otherJumpHeight = o.boundHeight;//踏んづけたものから跳ねる高さを取得する
                        o.playerStepOn = true;//踏んづけたものに対して踏んづけたことを通知する
                        jumpPos = transform.position.y;//ジャンプした位置を記録する
                        isOtherJump = true;
                        isJump = true;
                        jumpTime = 0.0f;
                    }
                    else
                    {
                        Debug.Log("objectCollsionがついてないよ！！！");
                    }
                }
                else
                {
                    //downする
　　　　　　　　　　anim.Play("Cat sibou");
            　　　　isSibou = true;
                    break;
                }
            }   
        }
        
    }
    #endregion


}
