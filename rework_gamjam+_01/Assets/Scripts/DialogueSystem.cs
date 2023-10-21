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
    // [SerializeField] Image npcImage;
    public GameObject dialogueStuff;
    // [SerializeField] DialogueLine[] dialogueLines;
    [SerializeField] Dialogues dialogues;
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
        textComponent.text = string.Empty;
        speakerText.text = "";
        originalPlayerScale = playerImage.rectTransform.localScale; // Store the original scale of the player image.
        originalNPCScale = dialogues.speakerImage.rectTransform.localScale; // Store the original scale of the NPC image.
        // StartDialogue();
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine(dialogues.dialogueLines[index].text));
        EmphasizeSpeaker(dialogues.dialogueLines[index].speaker);
        UpdateSpeakerNameUI(dialogues.dialogueLines[index].speaker);
    }

    IEnumerator TypeLine(string line)
    {
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
            playerImage.rectTransform.localScale = playerImageScale;
            dialogues.speakerImage.rectTransform.localScale = originalNPCScale; // Reset the NPC image scale.
        }
        else if (speaker == SpeakerType.NPC)
        {
            dialogues.speakerImage.rectTransform.localScale = npcImageScale;
            playerImage.rectTransform.localScale = originalPlayerScale; // Reset the player image scale.
        }
        else
        {
            playerImage.rectTransform.localScale = originalPlayerScale;
            dialogues.speakerImage.rectTransform.localScale = originalNPCScale;
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
        if (Input.GetMouseButtonDown(0))
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
