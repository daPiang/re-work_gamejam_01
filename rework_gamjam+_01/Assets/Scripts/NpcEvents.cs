using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcEvents : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    public void GiveItem(string itemName)
    {
        switch(itemName)
        {
            case "bag":
                inventory.hasArtistPack = true;
                break;
            case "blue":
                inventory.hasBlue = true;
                break;
            case "red":
                inventory.hasRed = true;
                break;
            case "yellow":
                inventory.hasYellow = true;
                break;
        }
    }
}
