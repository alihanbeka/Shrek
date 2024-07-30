using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    public static SlotManager Instance; // Singleton referansý

    public Inventory inventory; // Inventory referansý

    public List<InventorySlots> slots = new List<InventorySlots>();

    private void Awake()
    {
        Instance = this; // Singleton örneði ata
    }

    public bool RemoveItem(ItemType itemType)
    {
        return inventory.RemoveItem(itemType);
    }

    internal void RefreshSlots(List<Item> inventoryList)
    {
        // Önce tüm slotlarý temizle
        foreach (var slot in slots)
        {
            slot.ClearSlot();
        }
        if (inventoryList.Count > 0 && inventoryList[0] != null)
            Debug.Log("inventory list" + inventoryList[0].type);
        // Ardýndan envanterdeki öðeleri slotlara yerleþtir
        for (int i = 0; i < inventoryList.Count; i++)
        {

            slots[i].SetItem(inventoryList[i]);
            inventoryList[i].slotId = i;
            Debug.Log("slot id setted: " + i);
        }
    }

}
