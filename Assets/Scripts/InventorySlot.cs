using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class InventorySlot : IInventorySlot
    {
        public bool IsFull => amount == capacity;

        public bool IsEmpty => item == null;

        public IInventoryItem item {get; private set;}

        public Type itemType => item.type;

        public int amount => IsEmpty ? 0 : item.amount;

        public int capacity { get; private set; }

        public void Clear()
        {
            if(IsEmpty) return;

            item.amount = 0;
            item = null;
        }

        public void SetItem(IInventoryItem item)
        {
            if (!IsEmpty)
                return;

            this.item = item;
            this.capacity = item.maxItemsInInventorySlot;
        }
    }
}
