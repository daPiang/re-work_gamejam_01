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
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"){
            NextLevel();
        }
    }
    IEnumerator LoadLevel(){
        transition.SetTrigger("FadeOut");
        yield return new WaitForSeconds(transition.GetCurrentAnimatorStateInfo(0).length);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
        transition.SetTrigger("FadeIn");
    }
}
