using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    public Text message;

    public void ShowWinMessage(string winner)
    {
        message.text = winner + " has won this round!";
    }

    public void BackButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
