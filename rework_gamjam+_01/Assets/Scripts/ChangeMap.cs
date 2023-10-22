using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMap : MonoBehaviour
{
    SceneHandler sceneHandler;
    // Start is called before the first frame update
    void Start()
    {
        //tras = tra.GetComponent<SceneHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneHandler.instance.NextLevel();
        }
    }
}
