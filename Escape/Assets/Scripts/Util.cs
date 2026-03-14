using System.Collections.Generic;
using Data.Items;
using UnityEngine;

namespace Util
{
    public static class InvUtil
    {
        public static List<ItemBase> GetAllItems(List<ItemBase> itemDataBase)
        {
            return itemDataBase;
        }

        public static ItemBase GetItem(string name, List<ItemBase> itemDataBase)
        {
            foreach (var item in itemDataBase)
            {
                if (item.itemName == name)
                {
                    return item;
                }
            }

            Debug.LogError("Item not found: " + name);
            return null;
        }

        public static ItemBase GetItem(int id, List<ItemBase> itemDataBase)
        {
            if (id < 0 || id >= itemDataBase.Count)
            {
                Debug.LogError("Item ID out of range: " + id);
                return null;
            }

            foreach (var item in itemDataBase)
            {
                if (item.id == id) return item;
            }

            return null;
        }

        public static ItemBase AddItem(List<ItemBase> itemDataBase, List<ItemBase> inv, string name, int amount = 1)
        {
            var item = GetItem(name, itemDataBase);
            if (item != null)
            {
                for (int i = 0; i < amount; i++)
                {
                    inv.Add(item);
                }

                return item;
            }

            return null;
        }

        public static ItemBase AddItem(List<ItemBase> itemDataBase, List<ItemBase> inv, int id, int amount = 1)
        {
            var item = GetItem(id, itemDataBase);
            if (item != null)
            {
                for (int i = 0; i < amount; i++)
                {
                    inv.Add(item);
                }

                return item;
            }

            return null;
        }

        public static ItemBase AddItem(List<ItemBase> inv, ItemBase itemBase, int amount = 1)
        {
            if (itemBase != null)
            {
                for (int i = 0; i < amount; i++)
                {
                    inv.Add(itemBase);
                }

                return itemBase;
            }

            return null;
        }
    }
}