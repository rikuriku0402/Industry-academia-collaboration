using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoerItem : MonoBehaviour
{
    [Header("加算するスコア")] public int myScore;
    [Header("プレイヤーの判定")] public PlayerTriggerCheck playerCheck;
    [Header("ローテーション")] public float RotAngle = 4.0f;


    private Animator anim = null;
    // Update is called once per frame
    void Update()
    {
        anim = GetComponent<Animator>();
        //プレイヤーが判定内に入ったら
        if(playerCheck.isOn)
        {
            if(GManager.instance!=null)
            {
                GManager.instance.score += myScore;
                anim.Play("Star");
                Destroy(this.gameObject,0.2f);
            }
        }
    }
    private void FixedUpdate()
    {
        transform.Rotate(0f, 0f, -RotAngle);
    }
}
