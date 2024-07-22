using UnityEngine;

public class Item
{

    public ItemType type;
    public int amount;
    public string name;
    public Item(ItemType type, int amount, string name)
    {
        this.type = type;
        this.amount = amount;
        this.name = name;
    }

}
public enum ItemType
{
    heal,
    onion,
    pizza
}
