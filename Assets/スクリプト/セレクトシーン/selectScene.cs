using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    public class SelectScene : MonoBehaviour
{
    public void penguin1()
    {
        SceneManager.LoadScene("ペンギン一号");
    }
    public void penguin2()
    {
        SceneManager.LoadScene("ペンギン二号");
    }
    public void penguin3()
    {
        SceneManager.LoadScene("ペンギン三号");
    }
}