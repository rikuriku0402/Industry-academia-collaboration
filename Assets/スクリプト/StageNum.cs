using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageNum : MonoBehaviour
{
    private Text stageText = null;
    private int oldScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        stageText = GetComponent<Text>();
        if (GManager.instance != null)
        {
            stageText.text = "Score" + GManager.instance.stageNum;
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
        if (oldScore != GManager.instance.stageNum)
        {
            stageText.text = "Score" + GManager.instance.stageNum;
            oldScore = GManager.instance.stageNum;
        }
    }
}
