using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameSetting : MonoBehaviour
{
    public Toggle redCpu, redHuman;
    public Toggle blueCpu, blueHuman;


     void ReadToggle()
    {   //red - 0 
        if(redCpu.isOn)
        {
            SaveSettings.players[0] = "CPU";
        }
        else if (redHuman.isOn)
        {
            SaveSettings.players[0] = "HUMAN";
        }
        // blue - 1
        if (blueCpu.isOn)
        {
            SaveSettings.players[1] = "CPU";
        }
        else if (blueHuman.isOn)
        {
            SaveSettings.players[1] = "HUMAN";
        }
    }

    public void StartGame(string sceneName)
    {
        ReadToggle();
        SceneManager.LoadScene(sceneName);
    }
}

public static class SaveSettings
{
    // RED - 0
    // blue - 1

    public static string[] players = new string[2];

}