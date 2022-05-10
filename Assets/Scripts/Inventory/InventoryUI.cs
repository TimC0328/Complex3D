using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private Transform slots;

    void Awake()
    {
        slots = transform.GetChild(3);
    }

    void OnEnable()
    {
        int total = Inventory.Instance.items.Count;
        GameObject slot;
        for (int i = 0; i < Inventory.Instance.size; i++)
        {
            slot = slots.transform.GetChild(i).gameObject;
            if (i < total)
            {
                slot.SetActive(true);
                slot.GetComponent<Slot>().currentItem = Inventory.Instance.items[i];
                slot.transform.GetChild(1).gameObject.GetComponent<Text>().text = Inventory.Instance.items[i].itemName;
            }
            else
                slot.SetActive(false);
        }
    }
}
