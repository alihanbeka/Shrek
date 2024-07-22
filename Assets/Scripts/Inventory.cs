using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    public List<Item> items;

    public Inventory()
    {
        items = new List<Item>();
    }

    public void AddItem(Item newItem)
    {
        bool itemExists = false;

        foreach (Item item in items)
        {
            if (item.type == newItem.type)
            {
                item.amount += newItem.amount;
                itemExists = true;
                break;
            }
        }

        if (!itemExists)
        {
            items.Add(newItem);
        }

        Debug.Log("Item added: " + newItem.name);
    }


    public bool RemoveItem(ItemType itemType)
    {
        for (int i = items.Count - 1; i >= 0; i--)
        {
            Item item = items[i];
            if (item.type == itemType)
            {
                if (item.amount >= 0)
                {
                    item.amount -= 1;

                    // Eðer miktar 0 veya daha az olduysa, envanterden kaldýr
                    if (item.amount <= 0)
                    {
                        items.RemoveAt(i);
                    }

                    Debug.Log("Item removed: " + itemType + ", Amount: " + item.amount);
                    return true; // Baþarýyla çýkarýldý
                }
                else
                {
                    Debug.Log("Not enough items to remove.");
                    return false; // Yeterli miktar yok
                }
            }
        }

        Debug.Log("Item not found in inventory: " + itemType);
        return false; // Öðe bulunamadý
    }
}
