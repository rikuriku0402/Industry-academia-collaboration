using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = this.gameObject.transform.position;
        if(pos.y>=8f)
        {
            this.transform.position = new Vector2(0, pos.y -0.02f);
        }
    }
}
