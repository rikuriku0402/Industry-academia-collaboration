using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    private static Canvas gameclearCanvas;


    private void Start()
    {
        //Invoke("ペンギン一号1-2",2f);
    }

    private void Update()
    {

        
    }
    private void Awake()
    {
        gameclearCanvas = GetComponent<Canvas>();
    }

    public static void GameClearShowPanel()
    {
        Time.timeScale = 0f;

        gameclearCanvas.enabled = true;
    }

    /// <summary>
    /// ペンギン一号のステージスクリプト
    /// </summary>
    #region
    public void Stage1_1_2()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("ペンギン一号1-2");
    }
    public void Stage1_1_3()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("ペンギン一号1-3");
    }
    #endregion
    /// <summary>
    /// ペンギン二号のステージスクリプト
    /// </summary>
    #region
    public void Stage2_1_2()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("ペンギン二号1-2");
    }

    public void Stage2_1_3()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("ペンギン二号1-3");
    }
    #endregion
    /// <summary>
    /// ペンギン三号のステージスクリプト
    /// </summary>
    #region
    public void Stage3_1_2()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("ペンギン三号1-2");
    }
    public void Stage3_1_3()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("ペンギン三号1-3");
    }
    #endregion

    //すべてのステージが終わったら映画の宣伝のSceneに飛ぶ
    public void 映画宣伝()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("映画宣伝シーン");
    }
    public void TitleButton()
    {
        SceneManager.LoadScene(0);
    }
}
