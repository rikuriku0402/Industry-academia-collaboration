using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    [Header("フェード")] public fadeimage fade;

    private bool firstPush = false;
    private bool goNextScene = false;

    // Start is called before the first frame update
    public void GameStart()
    {
        if (!firstPush)
        {
            Debug.Log("ボタンが押されました");
            fade.StartFadeOut();
            firstPush = true;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (!goNextScene && fade.IsFadeOutComplete())
        {
            SceneManager.LoadScene(0);
            goNextScene = true;
        }
    }
}
