using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DokanMove : MonoBehaviour
{
    
    //GameObject型を変数Pointで宣言します
    public GameObject point;
    //GameObject型を変数charaで宣言します
    public GameObject chara;

    private void Start()
    {

    }
    //コライダーが乗った時の関数
    private void OnTriggerEnter2D(Collider2D other)
    {
        //もしピンクの土管に触れたときの処理
        if(other.name==chara.name)
        {
            //Charaが接触したらpointオブジェクトの位置に移動するよ
            chara.transform.position = point.transform.position;
        }
        
    }
    
}
