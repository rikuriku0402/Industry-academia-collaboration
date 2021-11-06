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

        private void Start()
        {
            // ゲームプレイ中、頻繁に呼び出されるコンポーネントは Start 内でキャッシュしておく
            // 毎回 GetComponent すると負荷が高くなるため
            rb = GetComponent<Rigidbody2D>();

            // 開始時のローカルスケールの値を記憶しておく
            defalutScale = transform.localScale;
        }

        private void Update()
        {
            // 左右方向の入力を受け取る
            var input_h = Input.GetAxis("Horizontal");

            Walk(input_h);

            Turn(input_h);
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

        // 向きを変える
        private void Turn(float inputValue)
        {
            if (inputValue > 0)
            {
                transform.localScale = defalutScale;
            }
            else if (inputValue < 0)
            {
                // ローカルスケールのXの値を反転させることで、スプライトを反転させる
                transform.localScale = new Vector3(-defalutScale.x, defalutScale.y, defalutScale.z);
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
