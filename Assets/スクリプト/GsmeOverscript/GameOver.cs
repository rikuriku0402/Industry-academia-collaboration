using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private static Canvas gameoverCanvas;


    private void Awake()
    {
        gameoverCanvas = GetComponent<Canvas>();
    }

    public static void GameOverShowPanel()
    {
        Time.timeScale = 0f;

        gameoverCanvas.enabled = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(6);
    }
}
