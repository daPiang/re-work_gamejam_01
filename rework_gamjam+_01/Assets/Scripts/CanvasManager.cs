using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject overlayCanvas;
    private void Update() {
        if(DialogueSystem.instance.dialogueStuff.activeSelf)
        {
            overlayCanvas.SetActive(false);
        }

        if(!DialogueSystem.instance.dialogueStuff.activeSelf)
        {
            overlayCanvas.SetActive(true);
        }
    }
}
