using UnityEngine;

namespace Assets.Scripts
{
    public class Tester: MonoBehaviour
    {
        private IInventory _inventory;

        private void Awake()
        {
            var inventoryCapacity = 10;
            _inventory = new InventoryWithSlots(inventoryCapacity);
            Debug.Log($"Inventory is created, capacity: {inventoryCapacity}");
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.A))
            {
                AddRandomApples();
            }
            if (Input.GetKeyUp(KeyCode.R))
            {
                RemoveRandomApples();
            }
        }
        private void AddRandomApples()
        {
            var rCount = Random.Range(0, 5);
            var apple = new Apple(5);
            apple.amount = rCount;
            _inventory.TryToAdd(this , apple);
        }

        private void RemoveRandomApples()
        {
            var rCount = Random.Range(1, 10);
            _inventory.Remove(this, typeof(Apple), rCount);
        }

    }
}
