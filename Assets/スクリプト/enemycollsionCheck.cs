using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycollsionCheck : MonoBehaviour
{
    [HideInInspector] public bool isOn = false;

    private string groundtag = "Ground";
    private string enemyTag = "Enemy";

    

    #region//接触判定
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag==groundtag||collision.tag==enemyTag)
        {
            isOn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundtag || collision.tag == enemyTag)
        {
            isOn = false;
        }
    }


    #endregion
}
