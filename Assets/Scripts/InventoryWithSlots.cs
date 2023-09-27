using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

namespace Assets.Scripts
{
    public class InventoryWithSlots : IInventory
    {
        public event Action<object, IInventoryItem, int> OnInventoryAddedEvent;
        public event Action<object, Type, int> OnInventoryRemoveEvent;
        public int capacity { get; set; }

        public bool isFull => _slots.All(slot => slot.IsFull);

        private List<IInventorySlot> _slots;

        public InventoryWithSlots(int capacity)
        {
            this.capacity = capacity;

            _slots = new List<IInventorySlot>(capacity);
            for (int i = 0; i < capacity; i++)
                _slots.Add(new InventorySlot());
        }

        public IInventoryItem[] GetAllItems()
        {
            var allitems = new List<IInventoryItem>();
            foreach(var slot in _slots)
            {
                if (!slot.IsEmpty)
                    allitems.Add(slot.item);
            }
            return allitems.ToArray();
        }

        public IInventoryItem[] GetAllItems(Type itemType)
        {
            var allitems = new List<IInventoryItem>();

            var slotsOfType = _slots.
                FindAll(slot => !slot.IsEmpty && slot.itemType == itemType);

            foreach(var slot in _slots)
                allitems.Add(slot.item);
            return allitems.ToArray();
        }

        public IInventoryItem[] GetEquippedItems()
        {
            var requireSlots = _slots.
                FindAll(slot => !slot.IsEmpty && slot.item.IsEquipped);
            var equippedItems = new List<IInventoryItem>();
            foreach (var slot in _slots)
                equippedItems.Add(slot.item);
            return equippedItems.ToArray();
        }

        public IInventoryItem GetItem(Type itemType)
        {
            return _slots.Find(slot => slot.itemType == itemType).item;
        }

        public int GetItemAmount(Type itemType)
        {
            var amount = 0;
            var allItemSlots = _slots.FindAll(slot => !slot.IsEmpty && slot.itemType == itemType);

            foreach(var slot in allItemSlots)
                amount += slot.amount;
            return amount;
        }


        public bool TryToAdd(object sender, IInventoryItem item)
        {
            var slotWithNameButNotEmpty = _slots.
                Find(slot => !slot.IsEmpty 
                && slot.itemType == item.type && !slot.IsFull);
            if(slotWithNameButNotEmpty != null)
                return TryToAddToSlot(sender, slotWithNameButNotEmpty, item);

            var emptySlot = _slots.Find(slot => slot.IsEmpty);
            if(emptySlot != null)
                return TryToAddToSlot(sender, emptySlot, item);

            return false;

        }
        private bool TryToAddToSlot(object sender, IInventorySlot slot, IInventoryItem item)
        {
            var fits = slot.amount + item.amount <= item.maxItemsInInventorySlot;
            var amountToAdd = fits 
                ? item.amount 
                : item.maxItemsInInventorySlot - slot.amount;
            var amountLeft = item.amount - amountToAdd;
            var clonedItem = item.Clone();
            clonedItem.amount = amountToAdd;

            if (slot.IsEmpty)
                slot.SetItem(clonedItem);
            else
                slot.item.amount += amountToAdd;

            Debug.Log($"item added to inventory. ItemType: {item.type}, amount: {amountToAdd}");
            OnInventoryAddedEvent?.Invoke(sender, item, amountToAdd);

            if(amountLeft >= 0)
                return true;


            item.amount = amountLeft;
            return TryToAdd(sender, item);
        }

        public void Remove(object sender, Type itemType, int amount = 1)
        {
            var slotsWithItem = ((IInventory)this).GetAllSlots(itemType);
            if (slotsWithItem.Length == 0)
                return;
            
            var amountToRemove = amount;

            var count = slotsWithItem.Length;

            for(int i = count - 1; i >= 0; i--)
            {
                var slot = slotsWithItem[i];
                if(slot.amount >= amountToRemove)
                {
                    slot.item.amount -= amountToRemove;

                    if(slot.amount <= 0)
                        slot.Clear();
                    Debug.Log($"item remove to inventory. ItemType: {itemType}, amount: {amountToRemove}");
                    OnInventoryRemoveEvent?.Invoke(sender, itemType, amountToRemove);

                    break;
                }

                var amountRemoved = slot.amount;
                amountToRemove -= slot.amount;
                slot.Clear();
                OnInventoryRemoveEvent?.Invoke(sender, itemType, amountRemoved);
            }

        }

        bool IInventory.HasItem(Type type, out IInventory item)
        {
            item = (IInventory)GetItem(type);
            return item != null;
        }
        IInventorySlot[] IInventory.GetAllSlots(Type itemType)
        {
            return _slots.
            FindAll(slot => !slot.IsEmpty
            && slot.itemType == itemType).ToArray();
        }

        IInventorySlot[] GetAllSlots()
        {
            return _slots.ToArray();
        }
    }
}
