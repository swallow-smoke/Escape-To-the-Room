using System.Collections.Generic;
using Data.Items;
using Data.SOJ;
using UnityEngine;

namespace Controller
{
    public class InventoryController : MonoBehaviour
    {
        public static InventoryController Instance;

        public List<ItemBase> items = new List<ItemBase>();
        public int maxItems = 28;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Inventory Controller already exists");
                Destroy(this);
                return;
            }

            Instance = this;
        }

        public void AddItem(ItemBase item)
        {
            if (items.Count >= maxItems)
            {
                Debug.Log("MaxItem");
                return;
            }
            
            items.Add(item);
            UI.InventoryPanel.RefreshInv();
        }

        public void RemoveItem(int index)
        {
            if (index < 0 || index >= items.count) return;
            
            items.RemoveAt(index);
            UI.InventoryPanel.RefreshInv();
        }
    }
}