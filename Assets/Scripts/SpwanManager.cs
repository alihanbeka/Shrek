using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    [SerializeField] GameObject spawnItem;
    int spawncount = 12;
    public void Start()
    {
        SpawnItems();
    }
    private void SpawnItems()
    {
        for (int i = 0; i < spawncount; i++)
        {
            GameObject spawnedItem = Instantiate(spawnItem);
            spawnedItem.transform.position = new Vector3 (Random.Range(-20, 20), Random.Range(-20, 20), 0);
            ItemWorld itemWoorld = spawnedItem.GetComponent<ItemWorld>();
            ItemType randomItemType = GetRandomEnumValue<ItemType>();
            itemWoorld.type = randomItemType;
            itemWoorld._amount = Random.Range(1, 3);
            itemWoorld.Setsprite();
        }

    }
    private T GetRandomEnumValue<T>()
    {
        System.Array values = System.Enum.GetValues(typeof(T));
        int randomIndex = Random.Range(0, values.Length);
        return (T)values.GetValue(randomIndex);
    }

}
    