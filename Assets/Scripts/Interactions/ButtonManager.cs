using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonManager : MonoBehaviour
{
    public int currScene = 0;
    static ButtonManager buttonManager = null;
    public string[] levelsNames;

    private void Start()
    {
        if (buttonManager == null)
        {
            buttonManager = this;
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
        SceneManager.LoadScene(levelsNames[currScene]);
        Debug.Log("Press");
        Destroy(gameObject);
    }


    public void PracticeRoom()
    {
        currScene = 1;
        SceneManager.LoadScene(levelsNames[currScene]);
        Debug.Log("Press");
    }


    public void MainMenu()
    {
        currScene = 0;
        SceneManager.LoadScene(levelsNames[currScene]);
        Debug.Log("Press");
        Destroy(gameObject);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}