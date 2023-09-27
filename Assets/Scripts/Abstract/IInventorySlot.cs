using System;

internal interface IInventorySlot
{
    bool IsFull { get; }
    bool IsEmpty { get; }

    IInventoryItem item { get; }
    Type itemType { get; }
    int amount { get; }
    int capacity { get; }


    void SetItem(IInventoryItem item);
    void Clear();
}
