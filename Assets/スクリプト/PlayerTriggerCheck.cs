using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerCheck : MonoBehaviour
{
    [HideInInspector] public bool isOn = false;

    private string playertag = "Player";
    



    #region//接触判定
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == playertag )
        {
            isOn = true;
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
