using UnityEngine;

public class Item
{

    public ItemType type;
    public int amount;
    public string name;
    public int slotId;
    public Item(ItemType type = ItemType.heal, int amount = 0, string name = "null", int slotId = 0)
    {
        this.type = type;
        this.amount = amount;
        this.name = name;
        this.slotId = slotId;
    }

}
public enum ItemType
{
    heal,
    onion,
    pizza,
    cookie
}
