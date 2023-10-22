using System.Collections;
using System.Collections.Generic;
using Destructible2D;
using UnityEngine;

public class ColorCheck : MonoBehaviour
{
    [SerializeField] private D2dDestructibleSprite desprite;
    [Range(0f, 1f)]
    public float threshold;

    [SerializeField] private Brush.ColorState colorState;
    public string clearsFlag;

    private void Update() {
        if((float)desprite.AlphaCount/desprite.OriginalAlphaCount <= threshold)
        {
            Debug.Log("Threshold Reached");
            // desprite.AlphaCount = 0;
            GetComponent<SpriteRenderer>().enabled = false;
            FlagSystem.instance.SetFlag(clearsFlag, true);
        }

        // Debug.Log(ColorMatch());
    }

    public bool ColorMatch()
    {
        return Brush.colorState == colorState;
    }
}
 