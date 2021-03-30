using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class ButtonManager : MonoBehaviour
{
    
    public int currScene = 0;
    static ButtonManager s = null;
    public string[] levelsNames;

    private void Start()
    {
        if (s == null)
        {
            s = this;
        }
        else
        {
            Destroy(this.gameObject);

        }

        DontDestroyOnLoad(this.gameObject);
    }





    public void MainRoom()
    {
        currScene = 2;
   
        SteamVR_LoadLevel.Begin(levelsNames[currScene]);
        Debug.Log("Press");
        Destroy(gameObject);
    }

    public void PracticeRoom()
    {
        currScene = 1;

        SteamVR_LoadLevel.Begin(levelsNames[currScene]);
        Debug.Log("Press");
    }

    public void MainMenu()
    {
        currScene = 0;

        SteamVR_LoadLevel.Begin(levelsNames[currScene]);
        Debug.Log("Press");
        Destroy(gameObject);
    }

    public void QuitGame()
    {
        Application.Quit();

    }
}
