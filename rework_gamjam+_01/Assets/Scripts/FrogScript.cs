using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    public GameObject popPanel;
    public GameObject mixerPanel;

    [SerializeField] Quest[] quests;   
    [SerializeField] Dialogues defaultDialog; 
    [SerializeField] private Inventory inventory;
    public int currentQuestIndex = 0;

    bool canInteract = true; // A flag to control interactions

    void Update()
    {
        Debug.Log(canInteract);
        // Debug.Log(talking);
        if(Input.GetKeyDown(KeyCode.F) && popPanel.activeSelf && canInteract)
        {
            ClickInteraction();
        }

        if(!DialogueSystem.instance.dialogueStuff.activeSelf)
        {
            if(!canInteract)canInteract = true;
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
        if (!canInteract)
        {
            return; // If interaction is not allowed, exit the function.
        }

        canInteract = false; // Disable interaction for a short period

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

            //Check if there's a reward
            if(quests[currentQuestIndex].hasReward)
            {
                GiveItem(quests[currentQuestIndex].reward);
            }

            //Check if we open mixer
            if(quests[currentQuestIndex].openMixer)
            {
                mixerPanel.SetActive(true);
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
    }
    
    public void GiveItem(string itemName)
    {
        switch(itemName)
        {
            case "bag":
                inventory.hasArtistPack = true;
                break;
            case "bluePaint":
                inventory.hasBlue = true;
                break;
            case "redPaint":
                inventory.hasRed = true;
                break;
            case "yellowPaint":
                inventory.hasYellow = true;
                break;
        }
    }
}

[System.Serializable]

public class Quest
{
    public Dialogues dialogues;
    public string flagRequirement; //be on this flag to enable certain dialogue
    public bool hasReward;
    public string reward;
    public bool openMixer;
}
