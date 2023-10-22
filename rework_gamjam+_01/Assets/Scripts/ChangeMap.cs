using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMap : MonoBehaviour
{
    SceneHandler sceneHandler;
    [SerializeField] private string flagToOpen;
    // Start is called before the first frame update
    void Start()
    {
        //tras = tra.GetComponent<SceneHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(FlagSystem.instance.GetFirstIncompleteFlag().flagName == flagToOpen)
        {
            GetComponent<Collider2D>().isTrigger = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && FlagSystem.instance.GetFirstIncompleteFlag().flagName == flagToOpen)
        {
            SceneHandler.instance.NextLevel();
        }
    }
}
