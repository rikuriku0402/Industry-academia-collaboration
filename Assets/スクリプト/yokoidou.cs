using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yokoidou : MonoBehaviour
{
    public float dx;
    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(dx * Time.deltaTime, 0, 0);
    }
}
