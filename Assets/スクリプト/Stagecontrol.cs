﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stagecontrol : MonoBehaviour
{
    [Header("プレイヤーゲームオブジェクト")] public GameObject playerObj;
    [Header("コンテニュー位置")] public GameObject[] continuePoint;


    private player p;
    // Start is called before the first frame update
    void Start()
    {
        if (playerObj != null && continuePoint != null && continuePoint.Length > 0)
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
    {

    }
}
