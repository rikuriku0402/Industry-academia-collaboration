using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjeCollsion : MonoBehaviour
{
    [Header("これを踏んだ時のプレイヤーが跳ねる高さ")] public float boundHeight;

    /// <summary>
    /// このオブジェクトをプレイヤーが踏んだかどうか
    /// </summary>
    [HideInInspector]public bool playerStepOn;
}
