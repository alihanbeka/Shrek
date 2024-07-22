using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlots : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI amountText;


    public void SetItem(Item item)
    {
        setItemIcon(item);
        amountText.text = item.amount.ToString();
    }

    private void setItemIcon(Item item)
    {
        var type = item.type;
        switch (type)
        {
            case ItemType.heal:
                icon.sprite = GameManager.instance.gameAssets.HealSprt;
                break;
            case ItemType.pizza:
                icon.sprite = GameManager.instance.gameAssets.pizzaSprt;
                break;
            case ItemType.onion:
                icon.sprite = GameManager.instance.gameAssets.onionSprt;
                break;
            default:
                icon.sprite = null;
                break;
        }
    }

    public void ClearSlot()
    {
        icon.sprite = null;
        amountText.text = "";
          
    }
    public void RemoveSlot(int id)
    { 
        Item item = PlayerCollisionController.instance._inventory.items[id];
        PlayerCollisionController.instance._inventory.RemoveItem(item.type);
        if(!PlayerCollisionController.instance._inventory.items.Exists(r => r.type == item.type))
            ClearSlot();

    }
}
