using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    public GameObject popPanel;

    [SerializeField] Quest[] quests;   
    [SerializeField] Dialogues defaultDialog; 
    public int currentQuestIndex = 0;

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
        if (other.gameObject.CompareTag("Player"))
        {
            popPanel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //MouseClick and Keyboard Control
        if (other.gameObject.CompareTag("Player"))
        {
            popPanel.SetActive(false);
        }
    }
    public void ClickInteraction()
    {
        // Debug.Log("Clicked");
        if(!DialogueSystem.instance.dialogueStuff.activeSelf)
        {
            DialogueSystem.instance.dialogueStuff.SetActive(true);
        }

        //Check if we're on the required flag to start quest 0
        if(FlagSystem.instance.GetFirstIncompleteFlag().flagName == quests[currentQuestIndex].flagRequirement)
        {
            //Set which dialogues the system will use
            DialogueSystem.instance.dialogues = quests[currentQuestIndex].dialogues;

            //Do the talk
            DialogueSystem.instance.StartDialogue();

            //Clear flag
            string flagToClear = quests[currentQuestIndex].dialogues.clearsFlag;
            if(flagToClear != "")
            {
                FlagSystem.instance.SetFlag(flagToClear, true);
            }

            //Increment quest index for this NPC
            currentQuestIndex++;
        }
        else
        {
            //Do Standard dialogue for the NPC
            DialogueSystem.instance.dialogues = defaultDialog;
            DialogueSystem.instance.StartDialogue();
        }

        // for(int i = 0; i < quests.Length - 1; i++)
        // {
        //     if(!quests[i].flagRequirement.completed)
        //     {

        //     }
        // }
    }
}

[System.Serializable]

public class Quest
{
    public Dialogues dialogues;
    public string flagRequirement; //be on this flag to enable certain dialogue
}
