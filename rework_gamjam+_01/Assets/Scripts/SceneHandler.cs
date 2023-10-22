using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneHandler: MonoBehaviour
{
    public static SceneHandler instance;
    [SerializeField] Animator transition;
    [SerializeField] GameObject pausePanel;
    public bool isClicked;
    // Update is called once per frame
    void Awake()
    {
        if(instance==null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }
    public void NextLevel(){
        Debug.Log("Clicked");
        StartCoroutine(LoadLevel());
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
    IEnumerator LoadLevel()
    {
        // Trigger the "FadeOut" animation
        transition.SetTrigger("FadeOut");

        // Wait for the animation to finish
        yield return new WaitForSeconds(transition.GetCurrentAnimatorClipInfo(0)[0].clip.length);

        // Determine the next scene index
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Check if the next scene index is valid
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // Load the next scene additively
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(nextSceneIndex, LoadSceneMode.Additive);

            // Wait until the next scene is fully loaded
            while (!loadOperation.isDone)
            {
                yield return null;
            }

            // Unload the current scene (optional)
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);

            // Set the newly loaded scene as the active scene
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(nextSceneIndex));

            // Trigger the "FadeIn" animation (you might want to add a delay if needed)
            transition.SetTrigger("FadeIn");
        }
        else
        {
            Debug.LogWarning("No more scenes to load.");
        }
    }

}
