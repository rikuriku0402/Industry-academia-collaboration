using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ペンギセレクト : MonoBehaviour
{
    public void Penguin1()
    {
        SceneManager.LoadScene("ペンギン1号ステージ");
    }
    public void Penguin2()
    {
        SceneManager.LoadScene("ペンギン2号ステージ");
    }
    public void Penguin3()
    {
        SceneManager.LoadScene("ペンギン3号ステージ");
    }


}
