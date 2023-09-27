using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Apple : IInventoryItem
    {
        public bool IsEquipped { get; set; }

        public Type type => GetType();

        public int maxItemsInInventorySlot { get; }

        public int amount { get; set; }

        public Apple(int maxItemsInInventorySlot) {
            this.maxItemsInInventorySlot = maxItemsInInventorySlot;
        }  
        public IInventoryItem Clone()
        {
            return new Apple(maxItemsInInventorySlot)
            {
                amount = this.amount
            };

        }
    }
}
