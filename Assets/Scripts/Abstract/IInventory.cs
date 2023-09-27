using System;

internal interface IInventory
{
    int capacity { get; set; }

    bool isFull { get; }

    IInventoryItem GetItem(Type itemType);
    IInventoryItem[] GetAllItems();
    IInventoryItem[] GetAllItems(Type itemType);
    IInventoryItem[] GetEquippedItems();
    int GetItemAmount(Type itemType);


    bool TryToAdd(object sender, IInventoryItem item);
    void Remove(object sender, Type itemType, int amount = 1);
    bool HasItem(Type type, out IInventory item);
    IInventorySlot[] GetAllSlots(Type itemType);
}
