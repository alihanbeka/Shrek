using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject Inventory;
    public SlotManager slotManager;

    Inventory inventory;
    private void Start()
    {
        inventory = PlayerCollisionController.instance._inventory;
    }
    void Update()

    {
        if (Input.GetKeyDown("p"))
        {
            Debug.Log("Pressed");
            if (Inventory.activeSelf== true)
            {
                Inventory.SetActive(false);
                
            }
            else
            {
                Inventory.SetActive(true);
                slotManager.RefreshSlots(inventory.items);
                
            }
        }
    }
}
