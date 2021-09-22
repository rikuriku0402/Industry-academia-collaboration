using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Haristage2 : MonoBehaviour
{
    [SerializeField] float m_loadTimer=2;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject, 0.1f);
            //StartCoroutine(WaitLoad(m_loadTimer));
        }
    }
    IEnumerator WaitLoad(float timer)
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
