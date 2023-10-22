using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem instance;
    

    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] TextMeshProUGUI speakerText;
    [SerializeField] Image playerImage;
    [SerializeField] Image npcImage;
    public GameObject dialogueStuff;
    // [SerializeField] DialogueLine[] dialogueLines;
    public Dialogues dialogues;
    public float textSpeed;
    public Vector3 playerImageScale = new Vector3(1.2f, 1.2f, 1.2f);
    public Vector3 npcImageScale = new Vector3(1.2f, 1.2f, 1.2f);
    private int index;
    private Vector3 originalPlayerScale;
    private Vector3 originalNPCScale;

    void Awake()
    {
        if(instance==null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if(dialogues != null)
        {
            textComponent.text = string.Empty;
            speakerText.text = "";
            originalPlayerScale = playerImage.rectTransform.localScale; // Store the original scale of the player image.
            originalNPCScale = npcImage.rectTransform.localScale; // Store the original scale of the NPC image.
            // StartDialogue();
        }
    }

    public void StartDialogue()
    {
        textComponent.text = string.Empty;
        speakerText.text = "";
        originalPlayerScale = playerImage.rectTransform.localScale; // Store the original scale of the player image.
        originalNPCScale = npcImage.rectTransform.localScale; // Store the original scale of the NPC image.
        index = 0; // Reset the index to start at the beginning of the dialogue.
        npcImage.sprite = dialogues.speakerImage;
        StartCoroutine(TypeLine(dialogues.dialogueLines[index].text));
        EmphasizeSpeaker(dialogues.dialogueLines[index].speaker);
        UpdateSpeakerNameUI(dialogues.dialogueLines[index].speaker);
    }


    IEnumerator TypeLine(string line)
    {
        textComponent.text = string.Empty; // Clear the text before typing a new line.
        foreach (char c in line.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }


    void EmphasizeSpeaker(SpeakerType speaker)
    {
        if (speaker == SpeakerType.Player)
        {
            // if(playerImage.rectTransform.localScale.x == originalNPCScale.x)
            // {
            //     playerImage.rectTransform.localScale *= 1.2f;
            // }
            npcImage.color = Color.gray;
            playerImage.color = Color.white;
        }
        else if (speaker == SpeakerType.NPC)
        {
            // if(npcImage.rectTransform.localScale.x == originalNPCScale.x)
            // {
            //     npcImage.rectTransform.localScale *= 1.2f;
            // }
            playerImage.color = Color.gray;
            npcImage.color = Color.white;
        }
        else
        {
            playerImage.color = Color.gray;
            npcImage.color = Color.gray;
        }
    }

    void UpdateSpeakerNameUI(SpeakerType speaker)
    {
        string speakerName = (speaker == SpeakerType.Player) ? "Player" : dialogues.speakerName;
        speakerText.text = speakerName;
    }

    void NextLine()
    {
        if (index < dialogues.dialogueLines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine(dialogues.dialogueLines[index].text));
            EmphasizeSpeaker(dialogues.dialogueLines[index].speaker);
            UpdateSpeakerNameUI(dialogues.dialogueLines[index].speaker);
            // index++;
        }
        else
        {
            // Reset the player and NPC images to their original scales.
            // playerImage.gameObject.SetActive(false);
            // npcImage.gameObject.SetActive(false);
            index = 0;
            dialogueStuff.SetActive(false);
        }
    }

    void Update()
    {
        // npcImage.sprite = dialogues.speakerImage;

        if (Input.GetMouseButtonDown(0) && dialogues != null)
        {
            if (textComponent.text == dialogues.dialogueLines[index].text)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = dialogues.dialogueLines[index].text;
            }
        }
    }
}

[System.Serializable]
public class DialogueLine
{
    public string text;
    public SpeakerType speaker;
}

public enum SpeakerType
{
    Player,
    NPC
}
