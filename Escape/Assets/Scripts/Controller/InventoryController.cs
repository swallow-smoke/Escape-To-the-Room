using System.Collections.Generic;
using Data.Items;
using Managers;
using UI;
using UI.Panel;
using UnityEngine;

namespace Controller
{
    public class InventoryController : MonoBehaviour
    {
        public List<ItemBase> items;
        public int maxItems = 28;

        private void Awake() => items = new List<ItemBase>();
        public void Reverse() => items.Reverse();
        public void Refresh()
        {
            
        }
    }
}