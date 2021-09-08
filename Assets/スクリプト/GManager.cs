using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
   

    public static GManager instance = null;
    
    [Header("スコア")]public int score;
    [Header("現在のステージ")] public int stageNum;
    [Header("現在の復帰位置")] public int continueNum;
    [Header("現在の残機")] public int heartNum;
    [Header("デフォルトの残機")] public int defaultHeartNum;
    [HideInInspector] public bool isGameOver;
    
    public Text textGameOver;//ゲームオーヴァーのテキスト
     void Start()
    {
        textGameOver.enabled = false;
    }
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    /// <summary>
    /// 残機を一つ増やす
    /// </summary>
    public void AddHeartNum()
    {
        if(heartNum<99)
        {
            ++heartNum;
        }
    }
    /// <summary>
    /// 残機を一つ減らす
    /// </summary>
    public void SubHeartNum()
    {
        if(heartNum>0)
        {
            --heartNum;
            
        }
        else
        {
            isGameOver = true;
            
        }
    }
    public void RetryGame()
    {
        isGameOver = false;
        heartNum = defaultHeartNum;
        score = 0;
        stageNum = 1;
        continueNum = 0;
        
    }

    GameObject PlayerObj = GameObject.Find("Player");
    void Update()
    {
        
        if (PlayerObj == null)
        {
            textGameOver.enabled = true;
        }
    }
}
