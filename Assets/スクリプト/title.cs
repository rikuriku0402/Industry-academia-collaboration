using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour
{
    [Header("フェード")] public fadeimage fade;

    private bool firstPush = false;
    private bool goNextScene = false;

    //スタートボタンを押されたら呼ばれる
    //public void PressStart()
    //{
    //Debug.Log("Press Start!");
    //if (firstPush)
    //{
    //    Debug.Log("Go Next Scene!");
    //    fade.StartFadeOut();
    //    firstPush = true;
    //}
    //}

    public void PressStart()
    {
        SceneManager.LoadScene("ペンギンセレクトシーン");
    }
}
