using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stagecontrol : MonoBehaviour
{
    [Header("プレイヤーゲームオブジェクト")] public GameObject playerObj;
    [Header("コンテニュー位置")] public GameObject[] continuePoint;
    [Header("ゲームオーバー")] public GameObject gameOverObj;//動画を見て追加した
    [Header("フェード")] public fadeimage fade;//動画を見て追加した


    private player p;
    
    private bool doGameOver = false;//動画を見て追加した
    



    void Start()
    {    
        gameOverObj.SetActive(false);//ゲームオーバーを初めに消す処理
        if (playerObj != null && continuePoint != null && continuePoint.Length > 0 && gameOverObj != null && fade != null)
        {
           
            playerObj.transform.position = continuePoint[0].transform.position;

            p = playerObj.GetComponent<player>();
            if (p == null)
            {
                Debug.Log("プレイヤーじゃないものがアタッチされているよ");
            }
        }
        else
        {
            Debug.Log("設定が足りてないよ");
        }
    }


    // Update is called once per frame
    void Update()
    {    //ゲームオーバー時の処理動画を見て追加した
        if (GManager.instance.isGameOver && !doGameOver)
        {
            gameOverObj.SetActive(true);
            doGameOver = true;
        }
        //プレイヤーがやられた時の処理動画を見て追加した
       else if(p!=null&&p && !doGameOver)
        {
            if(continuePoint.Length>GManager.instance.continueNum)
            {
                playerObj.transform.position = continuePoint[GManager.instance.continueNum].transform.position;
            }
        }
    }
}
