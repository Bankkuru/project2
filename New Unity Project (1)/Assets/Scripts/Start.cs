using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start: MonoBehaviour
{

    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    private void Update()
    {
        //gameManager.nScore = 0;
    }

}
