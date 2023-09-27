using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem
{
    bool IsEquipped { get; set; }
    Type type { get;}
    int maxItemsInInventorySlot { get; }
    int amount { get; set; }

    IInventoryItem Clone();
}
