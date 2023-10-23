using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{
    public static SceneHandler instance;
    [SerializeField] Animator transition;
    [SerializeField] GameObject pausePanel;
    public bool isClicked;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Example usage: Load a scene named "MyScene"
    //SceneHandler.instance.LoadSceneByName("MyScene");
    public void LoadSceneByName(string sceneName)
    {
        Debug.Log("Clicked");
        StartCoroutine(LoadScene(sceneName));
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void PausePlay()
    {
        if (!isClicked)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            isClicked = true;
        }
        else if (isClicked)
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            isClicked = false;
        }
    }

    IEnumerator LoadScene(string sceneName)
    {
        // Trigger the "FadeOut" animation
        transition.SetTrigger("FadeOut");

        // Wait for the animation to finish
        yield return new WaitForSeconds(transition.GetCurrentAnimatorClipInfo(0)[0].clip.length);

        // Load the next scene by name
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        // Wait until the next scene is fully loaded
        while (!loadOperation.isDone)
        {
            yield return null;
        }

        // Unload the current scene (optional)
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);

        // Set the newly loaded scene as the active scene
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));

        // Trigger the "FadeIn" animation (you might want to add a delay if needed)
        transition.SetTrigger("FadeIn");
    }
}
