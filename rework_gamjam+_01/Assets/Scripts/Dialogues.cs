using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue System/Dialogue")]
public class Dialogues : ScriptableObject
{
    [SerializeField] DialogueLine[] dialogueLines;
}
