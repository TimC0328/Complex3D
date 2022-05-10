using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string itemName;
    
    public enum ItemType { Keycard, Bypass, Weapon, Ammo};
    public ItemType itemType;

    public int amount;

}
