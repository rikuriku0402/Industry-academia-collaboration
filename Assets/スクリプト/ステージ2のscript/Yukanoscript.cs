using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yukanoscript : MonoBehaviour
{
    private Vector3 tragetPos;

    private void Start()
    {
        tragetPos = transform.position;
    }

    private void Update()
    {
        transform.position = new Vector3(Mathf.Sin(Time.time) * 3.0f + tragetPos.x, tragetPos.y, tragetPos.z);
    }
}
