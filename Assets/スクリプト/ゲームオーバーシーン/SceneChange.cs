using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    public void Retrybutton()
    {
        SceneManager.LoadScene("titleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
