using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject Inventory;
    public SlotManager slotManager;

  
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
                slotManager.RefreshSlots(PlayerCollisionController.instance._inventory.items);
                
            }
        }
    }
}
