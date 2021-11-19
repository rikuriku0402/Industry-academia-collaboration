using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerCheck : MonoBehaviour
{
    [HideInInspector] public bool isOn = false;

    private string playertag = "Player";

    [Header("リンゴを取った時のSE")]public AudioClip AppleSE;

    #region//接触判定
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == playertag )
        {
            isOn = true;
            SEManager.instance.PlaySE(AppleSE);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == playertag )
        {
            isOn = false;
        }
    }


    #endregion
}
