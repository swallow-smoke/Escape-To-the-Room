using System;
using System.Collections;
using System.Collections.Generic;
using Data.Items;
using Data.SOJ;
using Managers;
using UnityEngine;
using Util;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController instance;
        
        [SerializeField] public List<ItemBase> Inventory = new List<ItemBase>();
        [SerializeField] private StatusEffectController effectController;
        [SerializeField] private InventoryController invController;
        [SerializeField] public ItemDataBase DataBase;

        private void Start()
        {
            InvUtil.AddItem(DataBase.itemDataBase, Inventory, "FIRE", 2);
        }
    }
}
