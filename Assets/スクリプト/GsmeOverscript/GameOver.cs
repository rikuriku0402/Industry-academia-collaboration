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

    public void Restart1_1_1()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("ペンギン一号");
    }
    public void Restart1_1_2()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("ペンギン一号1-2");
    }

    public void Restart2_1_1()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("ペンギン二号");
    }
    public void Restart2_1_2()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("ペンギン二号1-2");
    }

    public void Restart3_1_1()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("ペンギン三号");
    }
    public void Restart3_1_2()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("ペンギン三号1-2");
    }

    public void title()
    {
        SceneManager.LoadScene(0);
    }
}
