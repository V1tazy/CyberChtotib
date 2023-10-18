using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Item> StartItems = new List<Item>();

    public List<Item> InventoryItems = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < StartItems.Count; i++)
        {
            ItemAdd(StartItems[i]);
        }
    }

    void ItemAdd(Item item)
    {
        InventoryItems.Add(item);
    }
}
