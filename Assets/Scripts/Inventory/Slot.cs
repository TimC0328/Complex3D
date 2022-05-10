using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public Item currentItem;

    public void ClickSlot()
    {
        Inventory.Instance.UseItem(currentItem);
    }
}
