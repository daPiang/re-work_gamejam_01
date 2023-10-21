using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] TextMeshProUGUI speakerText;
    [SerializeField] Image playerImage;
    [SerializeField] Image npcImage;
    [SerializeField] DialogueLine[] dialogueLines;
    public float textSpeed;
    public Vector3 playerImageScale = new Vector3(1.2f, 1.2f, 1.2f);
    public Vector3 npcImageScale = new Vector3(1.2f, 1.2f, 1.2f);
    private int index;
    private Vector3 originalPlayerScale;
    private Vector3 originalNPCScale;

    void Start()
    {
        textComponent.text = string.Empty;
        speakerText.text = "";
        originalPlayerScale = playerImage.rectTransform.localScale; // Store the original scale of the player image.
        originalNPCScale = npcImage.rectTransform.localScale; // Store the original scale of the NPC image.
        StartDialogue();
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine(dialogueLines[index].text));
        EmphasizeSpeaker(dialogueLines[index].speaker);
        UpdateSpeakerNameUI(dialogueLines[index].speaker);
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
            npcImage.rectTransform.localScale = originalNPCScale; // Reset the NPC image scale.
        }
        else if (speaker == SpeakerType.NPC)
        {
            npcImage.rectTransform.localScale = npcImageScale;
            playerImage.rectTransform.localScale = originalPlayerScale; // Reset the player image scale.
        }
        else
        {
            playerImage.rectTransform.localScale = originalPlayerScale;
            npcImage.rectTransform.localScale = originalNPCScale;
        }
    }

    void UpdateSpeakerNameUI(SpeakerType speaker)
    {
        string speakerName = (speaker == SpeakerType.Player) ? "Player" : "NPC";
        speakerText.text = speakerName;
    }

    void NextLine()
    {
        if (index < dialogueLines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine(dialogueLines[index].text));
            EmphasizeSpeaker(dialogueLines[index].speaker);
            UpdateSpeakerNameUI(dialogueLines[index].speaker);
        }
        else
        {
            // Reset the player and NPC images to their original scales.
            playerImage.gameObject.SetActive(false);
            npcImage.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == dialogueLines[index].text)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = dialogueLines[index].text;
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
