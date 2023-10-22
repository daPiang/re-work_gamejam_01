using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject colorPanel;
    [SerializeField] private Button blueButt, yellowButt, greenButt, redButt, violetButt, orangeButt;

    public static bool mixerMode = false;

    public void SetColor(string colorName)
    {
        switch(colorName)
        {
            case "blue":
                Brush.colorState = Brush.ColorState.Blue;
                break;
            case "yellow":
                Brush.colorState = Brush.ColorState.Yellow;
                break;
            case "green":
                Brush.colorState = Brush.ColorState.Green;
                break;
            case "red":
                Brush.colorState = Brush.ColorState.Red;
                break;
            case "violet":
                Brush.colorState = Brush.ColorState.Violet;
                break;
            case "orange":
                Brush.colorState = Brush.ColorState.Orange;
                break;
        }
    }

    private void Update() 
    {
        colorPanel.SetActive(inventory.hasArtistPack);
        blueButt.interactable = inventory.hasBlue;
        yellowButt.interactable = inventory.hasYellow;
        greenButt.interactable = inventory.hasGreen;
        redButt.interactable = inventory.hasRed;
        violetButt.interactable = inventory.hasViolet;
        orangeButt.interactable = inventory.hasOrange;

        // Debug.Log(Brush.colorState);
    }
}
 