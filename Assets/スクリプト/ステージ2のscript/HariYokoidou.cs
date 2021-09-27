using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HariYokoidou : MonoBehaviour
{
    public float length = 4.0f;
    public float speed = 2.0f;
    private Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2((Mathf.Sin((Time.time) * speed) * length + startPos.x), startPos.y);
    }
}
