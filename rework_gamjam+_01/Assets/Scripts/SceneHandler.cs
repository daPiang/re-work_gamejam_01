using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneHandler: MonoBehaviour
{
    public static SceneHandler instance;
    [SerializeField] Animator transition;
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
