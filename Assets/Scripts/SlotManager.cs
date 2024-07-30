using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    public static SlotManager Instance; // Singleton referans�

    public Inventory inventory; // Inventory referans�

    public List<InventorySlots> slots = new List<InventorySlots>();

    private void Awake()
    {
        Instance = this; // Singleton �rne�i ata
    }

    public bool RemoveItem(ItemType itemType)
    {
        return inventory.RemoveItem(itemType);
    }

    internal void RefreshSlots(List<Item> inventoryList)
    {
        // �nce t�m slotlar� temizle
        foreach (var slot in slots)
        {
            slot.ClearSlot();
        }
        if (inventoryList.Count > 0 && inventoryList[0] != null)
            Debug.Log("inventory list" + inventoryList[0].type);
        // Ard�ndan envanterdeki ��eleri slotlara yerle�tir
        for (int i = 0; i < inventoryList.Count; i++)
        {

            slots[i].SetItem(inventoryList[i]);
            inventoryList[i].slotId = i;
            Debug.Log("slot id setted: " + i);
        }
    }

}
