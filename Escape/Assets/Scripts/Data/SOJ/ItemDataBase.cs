using System;
using System.Collections.Generic;
using Data.Items;
using UnityEngine;

namespace Data.SOJ
{
    [CreateAssetMenu(fileName = "ItemDataBase", menuName = "Item/ItemDataBase"), System.Serializable]
    public class ItemDataBase : ScriptableObject
    {
        public List<ItemBase> itemDataBase;
    }
}