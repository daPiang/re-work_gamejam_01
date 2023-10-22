using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMix : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    public void AddColor(string colorName) //for adding the mixed colors
    {
        switch(colorName)
        {
            case "green":
                inventory.hasGreen = true;
                FlagSystem.instance.SetFlag("colormix1", true);
                break;
            case "violet":
                inventory.hasViolet = true;
                FlagSystem.instance.SetFlag("colormix2", true);
                break;
            case "orange":
                inventory.hasOrange = true;
                FlagSystem.instance.SetFlag("colormix3", true);
                break;
        }
    }
}
 