using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationYuka : MonoBehaviour
{
    //[Header("ローテーション")] public float RotAngle = 4.0f;
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, 5));
    }
}
