using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;
    
    [Header("スコア")]public int score;
    [Header("現在のステージ")] public int stageNum;
    [Header("現在の復帰位置")] public int continueNum;
    [Header("現在の残機")] public int heartNum;
    [Header("デフォルトの残機")] public int defaultHeartNum;
    [Header("コンテニュー位置")] public GameObject continuePoint;
    [HideInInspector] public bool isGameOver;
    
    
     void Start()
    {
        
    }
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //Destroy(this.gameObject);
        }
    }
    public void RetryGame()
    {
        isGameOver =enabled= false;
        score = 0;
        stageNum = 1;
        continueNum = 0;
    }

    public void Respawn(GameObject Player)
    {
        Player.transform.position = continuePoint.transform.position;
    }
}
