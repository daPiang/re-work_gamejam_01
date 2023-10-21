using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    public GameObject popPanel;

    [SerializeField] Dialogues dialogues;    

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && popPanel.activeSelf)
        {
            ClickInteraction();
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        //MouseClick and Keyboard Control
        if (other.gameObject.tag == "Player")
        {
            popPanel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //MouseClick and Keyboard Control
        if (other.gameObject.tag == "Player")
        {
            popPanel.SetActive(false);
        }
    }
    public void ClickInteraction()
    {
        DialogueSystem.instance.dialogues = dialogues;
        // Debug.Log("Clicked");
        if(!DialogueSystem.instance.dialogueStuff.activeSelf)
        {
            DialogueSystem.instance.dialogueStuff.SetActive(true);
        }
        DialogueSystem.instance.StartDialogue();
    }
}
