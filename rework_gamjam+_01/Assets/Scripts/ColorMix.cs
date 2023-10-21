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
                break;
            case "violet":
                inventory.hasViolet = true;
                break;
            case "orange":
                inventory.hasOrange = true;
                break;
        }
    }
}
 