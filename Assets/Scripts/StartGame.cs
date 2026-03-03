using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            StartCoroutine("StartNextLevel");
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }

    IEnumerator StartNextLevel(){
        yield return null;
        SceneManager.LoadScene(1);
    }
}
