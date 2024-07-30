using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlots : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI amountText;
    public int id;

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
                icon.gameObject.SetActive(true);
                icon.sprite = GameManager.instance.gameAssets.HealSprt;
                break;
            case ItemType.pizza:
                icon.gameObject.SetActive(true);
                icon.sprite = GameManager.instance.gameAssets.pizzaSprt;
                break;
            case ItemType.onion:
                icon.gameObject.SetActive(true);
                icon.sprite = GameManager.instance.gameAssets.onionSprt;
                break;
            default:
                icon.gameObject.SetActive(false);
                icon.sprite = null;
                break;
        }
    }

    public void ClearSlot()
    {
        icon.gameObject.SetActive(false);
        icon.sprite = null;
        amountText.text = "";

    }
    public void RemoveSlot(int id)
    {
        Item item = new Item();
        item = PlayerCollisionController.instance._inventory.items[id];
        if (item == null)
        {
            for (int i = 0; i < id; i++)
            {
                item = PlayerCollisionController.instance._inventory.items[id];
                if (item != null)
                    break;
                else
                    id--;
            }
        }

        if (item == null)
            item = PlayerCollisionController.instance._inventory.items[id - 1];

        PlayerCollisionController.instance._inventory.RemoveItem(item.type);
        if (!PlayerCollisionController.instance._inventory.items.Exists(r => r.type == item.type))
            ClearSlot();
        SlotManager.Instance.RefreshSlots(PlayerCollisionController.instance._inventory.items);


    }

}
