using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeimage : MonoBehaviour
{
    [Header("最初からフェードインが完了しているかどうか")] public bool firstFadeInComp;

    private Image img = null;
    private int frameCount = 0;
    private float timer = 0.0f;
    private bool fadeIn = false;
    private bool fadeOut = false;
    private bool compFadeIn = false;
    private bool compFadeOut = false;

    /// <summary>
    /// フェードインを開始する
    /// </summary>
    public void StartFadeIn()
    {
        if (fadeIn || fadeOut)
        {
            return;
        }
        fadeIn = true;
        compFadeIn = false;
        timer = 0.0f;
        img.color = new Color(1, 1, 1, 1);
        img.fillAmount = 1;
        img.raycastTarget = true;
    }

    /// <summary>
    /// フェードインが完了したかどうか
    /// </summary>
    /// <returns></returns>
    public bool IsFadeInComplete()
    {
        return compFadeIn;
    }

    /// <summary>
    /// フェードアウトを開始する
    /// </summary>
    public void StartFadeOut()
    {
        if (fadeIn || fadeOut)
        {
            return;
        }
        fadeOut = true;
        compFadeOut = false;
        timer = 0.0f;
        img.color = new Color(1, 1, 1, 0);
        img.fillAmount = 0;
        img.raycastTarget = true;
    }

    /// <summary>
    /// フェードアウトを完了したかどうか
    /// </summary>
    /// <returns></returns>
    public bool IsFadeOutComplete()
    {
        return compFadeOut;
    }

    void Start()
    {
        img = GetComponent<Image>();
        if (firstFadeInComp)
        {
            FadeInComplete();
        }
        else
        {
            StartFadeIn();
        }
    }

    void Update()
    {
        //シーン移行時の処理の重さでTime.deltaTimeが大きくなってしまうから2フレーム待つ
        if (frameCount > 2)
        {
            if (fadeIn)
            {
                FadeInUpdate();
            }
            else if (fadeOut)
            {
                FadeOutUpdate();
            }
        }
        ++frameCount;
    }

    //フェードイン中
    private void FadeInUpdate()
    {
        if (timer < 1f)
        {
            img.color = new Color(1, 1, 1, 1 - timer);
            img.fillAmount = 1 - timer;
        }
        else
        {
            FadeInComplete();
        }
        timer += Time.deltaTime;
    }

    //フェードアウト中
    private void FadeOutUpdate()
    {
        if (timer < 1f)
        {
            img.color = new Color(1, 1, 1, timer);
            img.fillAmount = timer;
        }
        else
        {
            FadeOutComplete();
        }
        timer += Time.deltaTime;
    }

    //フェードイン完了
    private void FadeInComplete()
    {
        img.color = new Color(1, 1, 1, 0);
        img.fillAmount = 0;
        img.raycastTarget = false;
        timer = 0.0f;
        fadeIn = false;
        compFadeIn = true;
    }

    //フェードアウト完了
    private void FadeOutComplete()
    {
        img.color = new Color(1, 1, 1, 1);
        img.fillAmount = 1;
        img.raycastTarget = false;
        timer = 0.0f;
        fadeOut = false;
        compFadeOut = true;
    }
}