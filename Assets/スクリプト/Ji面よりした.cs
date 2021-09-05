using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ji面よりした : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene("ステージ１");
        }
        else if(transform.position.y<-8)
        {
            SceneManager.LoadScene("ステージ１");
        }
    }
}
