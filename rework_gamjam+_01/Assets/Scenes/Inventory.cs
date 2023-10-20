using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class Inventory : ScriptableObject
{
    public bool hasArtistPack;
    public bool hasBlue;
    public bool hasYellow;
    public bool hasRed;
}
