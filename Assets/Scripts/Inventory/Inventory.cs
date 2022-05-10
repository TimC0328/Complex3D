using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private static Inventory _instance;
    public static Inventory Instance { get { return _instance; } }
    // Start is called before the first frame update
    public List<Item> items = new List<Item>();
    public int size = 10;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    bool AddItem(Item item)
    {
        foreach (Item i in items)
        {
            if(i.itemName == item.itemName)
            {
                i.amount += item.amount;
                return true;
            }
        }
        if (items.Count >= size)
            return false;
        items.Add(item);
        Debug.Log("Added " + item.itemName + " into inventory");
        return true;

    }

    public void UseItem(Item item)
    {
        Debug.Log("Using " + item.itemName);
        switch (item.itemType)
        {
            case Item.ItemType.Bypass:
                items.Remove(item);
                return;
            default:
                return;
        }
    }
}
