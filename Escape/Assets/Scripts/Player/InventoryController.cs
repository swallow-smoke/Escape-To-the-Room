using System.Collections.Generic;
using Data.Items;
using Data.SOJ;
using UnityEngine;

namespace Player
{
    public class InventoryController : MonoBehaviour
    {
        public static InventoryController Instance;

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
    }
}