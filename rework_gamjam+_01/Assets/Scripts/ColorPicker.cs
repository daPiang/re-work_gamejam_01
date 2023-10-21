using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
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
}
 