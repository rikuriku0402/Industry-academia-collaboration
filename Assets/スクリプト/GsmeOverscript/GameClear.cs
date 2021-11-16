using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    private static Canvas gameclearCanvas;


    private void Awake()
    {
        gameclearCanvas = GetComponent<Canvas>();
    }

    public static void GameClearShowPanel()
    {
        Time.timeScale = 0f;

        gameclearCanvas.enabled = true;
    }

    public void NextStageGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("次のステージをかけ");
    }
}
