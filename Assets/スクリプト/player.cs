using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class player : MonoBehaviour
{
    #region//インスペクターで設定する
    [SerializeField]  float Speed = 1000f;
    [Header("重力")] public float gravity;
    [Header("ジャンプ速度")] public float jumpSpeed;
    [Header("ジャンプする高さ")] public float jumpHeight;
    [Header("ジャンプする制限時間")] public float jumpLimitTime;
    [Header("踏みつけ判定の高さの割合")] public float stepOnRate;
    [Header("ジャンプフォース")] public float jumpForce = 200.0f;
    [Header("設置判定")] public GrouneCheck ground;
    [Header("頭をぶつけた判定")] public GrouneCheck head;
    [Header("ダッシュの速さ表現")] public AnimationCurve dashCurve;
    [Header("ジャンプの速さ表現")] public AnimationCurve jumpCurve;
    [Header("ゴールオブジェクトをつける")] public GameObject goal;
    public Text GameOvertext;
    public int life;

    //public Text textGameOver;//ゲームオーヴァーのテキスト

    #endregion

    #region//プライベート変数
    //private Animator anim = null;
    private Rigidbody2D rb = null;
    private CapsuleCollider2D capcol = null;
    private FloorMove moveObj = null;
    private bool isGround = false;
    private bool isHead = false;
    private bool isJump = false;
    private bool isRun = false;
    private bool isSibou = false;
    private bool isDown = false;
    private bool isOtherJump = false;
    private float jumpPos = 0.0f;
    private float otherJumpHeight = 0.0f;
    private float jumpTime = 0.0f;
    private string enemyTag = "Enemy";
    private string fallFloorTag = "FloorFall";
    private string moveFloorTag = "MoveFloor";


    #endregion

    void Start()
    {
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        capcol = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (!isSibou && !GManager.instance.isGameOver)
        {
            //接地判定を得る
            isGround = ground.IsGround();
            isHead = head.IsGround();

            

            //アニメーションを適用
            SetAnimation();

            //移動速度を設定
            Vector2 addVelocity = Vector2.zero;
            if (moveObj != null)
            {
                addVelocity = moveObj.GetVelocity();
            }
            
        }
        else
        {
            rb.velocity = new Vector2(0, -gravity);
        }
    }

    
    private void SetAnimation()
    {
        //anim.SetBool("jump", isJump || isOtherJump);
        //anim.SetBool("ground", isGround);
        //anim.SetBool("run", isRun);
    }

    

    
    #region//ライフ
    /// <summary>
    /// ライフを追加ゆっぴーはいじっちゃだめよ❤
    /// </summary>
    ///
    void Life()
    {
        if (GManager.instance.heartNum > 0)
        {
            GManager.instance.heartNum -= 1;
            GManager.instance.Respawn(gameObject);
            Debug.Log(GManager.instance.heartNum);


        }
        else if (GManager.instance.heartNum <= 0)
        {
            //GameOvertext.gameObject.SetActive(true);
            StartCoroutine(WaitLoad(0.5f));
        }
    }
    IEnumerator WaitLoad(float timer)
    {
        fadeimage.Instance.StartFadeOut();
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene("ゲームオーバー画面");

    }
    #endregion

    #region//接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool enemy = (collision.collider.tag == enemyTag);
        bool moveFloor = (collision.collider.tag == moveFloorTag);
        bool fallFloor = (collision.collider.tag == fallFloorTag);

        if (enemy || moveFloor || fallFloor)
        {
            //踏みつけ判定になる高さ
            float stepOnHeght = (capcol.size.y * (stepOnRate / 100f));
            //踏みつけ判定のワールド座標
            float judgePos = transform.position.y - (capcol.size.y / 2f) + stepOnHeght;

            foreach (ContactPoint2D p in collision.contacts)
            {
                if (p.point.y < judgePos)
                {
                    if (enemy || fallFloor)
                    {
                        //もう一度跳ねる
                        ObjeCollsion o = collision.gameObject.GetComponent<ObjeCollsion>();
                        if (o != null)
                        {
                            if (enemy)
                            {
                                otherJumpHeight = o.boundHeight;//踏んづけたものから跳ねる高さを取得する
                                o.playerStepOn = true;//踏んづけたものに対して踏んづけたことを通知する
                                jumpPos = transform.position.y;//ジャンプした位置を記録する
                                isOtherJump = true;
                                isJump = false;
                                jumpTime = 0.0f;
                            }
                            else if (fallFloor)
                            {
                                o.playerStepOn = true;
                            }
                        }

                        else
                        {
                            Debug.Log("objectCollsionがついてないよ！！！");
                        }
                    }
                    else if (moveFloor)
                    {
                        moveObj = collision.gameObject.GetComponent<FloorMove>();
                    }
                }
                else
                {
                    if (enemy)
                    {
                        
                        break;
                    }
                }
            }
        }
        else if (collision.collider.tag == moveFloorTag)
            {
                //踏みつけ判定になる高さ
                float stepOnHeight = (capcol.size.y * (stepOnRate / 100f));
                //踏みつけ判定のワールド座標
                float judgePos = transform.position.y - (capcol.size.y / 2f) + stepOnHeight;
                foreach (ContactPoint2D p in collision.contacts)
                {
                    //動く床に乗っている
                    if (p.point.y < judgePos)
                    {

                    }
                }
            }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == moveFloorTag)
        {
            //動く床から離れた
            moveObj = null;
        }
    }
    #endregion
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            Destroy(other.gameObject);

        }
        else if (other.gameObject == goal)
        {
            SceneManager.LoadScene("クリア画面");
        }
        else if (other.tag == "Enemy")
        {
            Life();
        }
    }
}
