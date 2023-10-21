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

    private void Update() {
        if((float)desprite.AlphaCount/desprite.OriginalAlphaCount <= threshold)
        {
            Debug.Log("Threshold Reached");
        }

        Debug.Log(ColorMatch());
    }

    public bool ColorMatch()
    {
        return Brush.colorState == colorState;
    }
}
 