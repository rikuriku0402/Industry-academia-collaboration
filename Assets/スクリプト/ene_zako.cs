using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ene_zako : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("加算スコア")] public int myScore;
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("画面外でも行動するが")] public bool nonVisible;
    [Header("接触判定")]public enemycollsionCheck checkCollision;
    #endregion

    #region//プライベート変数
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private Animator anim = null;
    private ObjeCollsion oc = null;
    private BoxCollider2D col = null;
    private bool rightTleftF = false;
    private bool isDead = false;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        oc = GetComponent<ObjeCollsion>();
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!oc.playerStepOn)
        {
            if (sr.isVisible || nonVisible)
            {
                if(checkCollision.isOn)
                {
                    rightTleftF = !rightTleftF;
                }
                int xVector = -1;
                if (rightTleftF)
                {
                    xVector = 1;
                    transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
                }
                else
                {
                    transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                }
                rb.velocity = new Vector2(xVector * speed, -gravity);
            }
            else
            {
                rb.Sleep();
            }
        }
            else
            {
                if(!isDead)
                {
                anim.Play("enemy cat");
                rb.velocity = new Vector2(0, -gravity);
                isDead = true;
                col.enabled = false;
                if (GManager.instance!=null) 
                {
                    GManager.instance.score += myScore;
                }
                Destroy(gameObject, 1f);
                }
                else
            {
                transform.Rotate(new Vector3(0, 0, 3));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject, 3.0f);
            SceneManager.LoadScene("ステージ１");
        }
        else if (transform.position.y < -8)
        {
            SceneManager.LoadScene("ステージ１");
        }
    }

}
