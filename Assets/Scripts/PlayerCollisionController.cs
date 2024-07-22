using UnityEngine;
using static UnityEditor.Progress;

public class PlayerCollisionController : MonoBehaviour
{
    private Inventory inventory;
    public Inventory _inventory { get { return inventory; } }
    public static PlayerCollisionController instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        inventory = new Inventory();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            ItemWorld itemComponent = other.gameObject.GetComponent<ItemWorld>();
            if (itemComponent != null)
            {
                // Yeni Item nesnesi oluþturma
                Item item = new Item(itemComponent.type, itemComponent._amount, itemComponent.name);
                inventory.AddItem(item);
                SlotManager slotManager = FindObjectOfType<SlotManager>();
                slotManager.RefreshSlots(inventory.items);
                Destroy(other.gameObject); // Ýtemi sahneden kaldýr
                Debug.Log("Collected");
            }
        }

    }
}
