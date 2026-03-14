using Data.Items;
using Data.Object;
using Data.SOJ;
using Player;
using UnityEngine;
using Util;

namespace Prefabs.Structure
{
    public class Cabinet : StructureBase, IHoldable, ISelectable
    {
        [SerializeField] public string itemName;
        [SerializeField] public int weight { get; set; }
        
        public override void OnSelect()
        {
            base.OnSelect();
            Debug.Log("Selected cabinet");
            Debug.Log(PlayerController.instance.Inventory);
            Debug.Log(PlayerController.instance.DataBase.itemDataBase);
            InvUtil.AddItem(PlayerController.instance.DataBase.itemDataBase, PlayerController.instance.Inventory, itemName, 2);
        }

        public override void OnDeselect()
        {
            
        }

        public void OnHold()
        {
            
        }
    }
}