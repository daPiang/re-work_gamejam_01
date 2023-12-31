using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue System/Dialogue")]
public class Dialogues : ScriptableObject
{
    public DialogueLine[] dialogueLines;
    public string speakerName;
    public  Sprite speakerImage;
    public string clearsFlag; //clears flag after dialogue
}
