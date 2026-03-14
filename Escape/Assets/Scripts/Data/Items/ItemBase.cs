using Player;
using UnityEngine;

namespace Data.Items
{
    [System.Serializable]
    public class ItemBase
    {
        [SerializeField] public bool consumable;
        [SerializeField] public string description;
        [SerializeField] public string itemName;
        [SerializeField] public int id;

        public bool Use(PlayerController player)
        {
            if (consumable) return true;
            else return false;
        }
    }
}