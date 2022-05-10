using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private GameObject inventorySystem;
    
    void Awake()
    {
        inventorySystem = transform.GetChild(2).gameObject;
    }

    public void ToggleInventorySystem()
    {
        GameManager.Instance.navi.usingScreen = !GameManager.Instance.navi.usingScreen;
        inventorySystem.SetActive(!inventorySystem.activeSelf);
    }
}
