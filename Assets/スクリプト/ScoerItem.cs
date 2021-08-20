using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoerItem : MonoBehaviour
{
    [Header("加算するスコア")] public int myScore;
    [Header("プレイヤーの判定")] public PlayerTriggerCheck playerCheck;

    // Update is called once per frame
    void Update()
    {
        //プレイヤーが判定内に入ったら
        if(playerCheck.isOn)
        {
            if(GManager.instance!=null)
            {
                GManager.instance.score += myScore;
                Destroy(this.gameObject);
            }
        }
    }
}
