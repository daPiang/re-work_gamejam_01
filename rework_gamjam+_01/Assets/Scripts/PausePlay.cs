using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class PausePlay : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    SceneHandler scenehand;
    public bool isClicked;
    public PlayerController playerCont;
    public void Pauseplay()
    {
        if (!isClicked)
        {
            playerCont.enabled = false;
            pausePanel.SetActive(true);
            isClicked = true;
        }
        else if (isClicked)
        {
            playerCont.enabled = true;
            pausePanel.SetActive(false);
            isClicked = false;
        }
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void MenuButton()
    {
        SceneHandler.instance.LoadSceneByName("Menu");
    }
    public void OneButton()
    {
        SceneHandler.instance.LoadSceneByName("LevelOne");
    }
    public void TwoButton()
    {
        SceneHandler.instance.LoadSceneByName("LevelTwo");
    }
    public void FinaleButton()
    {
        SceneHandler.instance.LoadSceneByName("Finele");
    }

}
