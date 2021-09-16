﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    private Text heartText = null;
    private int oldScore = 0;
    //public Text textGameOver;//ゲームオーヴァーのテキスト

    void Start()
    {
        heartText = GetComponent<Text>();
        if (GManager.instance != null)
        {
            heartText.text = "×" + GManager.instance.heartNum;
        }
        else
        {
            Debug.Log("ゲームマネージャー置き忘れてるよ！");
            Destroy(this);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (oldScore != GManager.instance.heartNum)
        {
            heartText.text = "×" + GManager.instance.heartNum;
            oldScore = GManager.instance.heartNum;
        }

        {
            //if (oldScore != 0)
            //{
            //    textGameOver.enabled = true;
            //}
        }
    }
}
