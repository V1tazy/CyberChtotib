using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
{
    [SerializeField] Inventory InventoryTarget;
    [SerializeField] RectTransform itemsPanel;
    void Start()
    {
        
    }
    
    void Redraw()
    {
        for (int i = 0; i < InventoryTarget.InventoryItems.Count; i++)
        {
            var item = InventoryTarget.InventoryItems[i];

            var icon = new GameObject("Icon");
            icon.AddComponent<Image>().sprite = item.Icon;
        }
    }
}
