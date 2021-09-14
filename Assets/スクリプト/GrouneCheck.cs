using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrouneCheck : MonoBehaviour
{
    #region
    [Header("エフェクトがついた床を判定するが")] public bool checkPlatformGound = true;
    private string groundTag = "Ground";
    private string platformTag = "GroundPlatform";
    private string MoveFlooTag = "MoveFloor";
    private string fallFloorTag = "FallFloor";
    private bool isGround = false;
    private bool isGroundEnter,isGroundStay, isGroundExit;
    #endregion
    // Start is called before the first frame update

    //物理判定の更新毎呼ぶ必要がある
    public bool IsGround()
    {
        if (isGroundEnter || isGroundStay)
        {
            isGround = true;
        }
        else if (isGroundExit)
        {
            isGround = false;
        }

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return isGround;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundEnter = true;
        }
        else if(checkPlatformGound&&(collision.tag==platformTag||
            collision.tag==MoveFlooTag||collision.tag==fallFloorTag))
        {
            isGroundEnter = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundStay = true;
        }
        else if(checkPlatformGound&&(collision.tag==platformTag||
            collision.tag==MoveFlooTag||collision.tag==fallFloorTag))
        {
            isGroundStay = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundExit = true;
        }
        else if(checkPlatformGound&&(collision.tag==platformTag||
            collision.tag==MoveFlooTag||collision.tag==fallFloorTag))
        {
            isGroundExit = true;
        }
    }
}
