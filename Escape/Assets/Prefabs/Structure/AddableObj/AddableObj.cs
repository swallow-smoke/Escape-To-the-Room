using Data.Items;
using Data.Object;
using Data.SOJ;
using Player;
using UnityEngine;
using Util;

namespace Prefabs.Structure
{
    public class AddableObj : StructureBase, IHoldable, ISelectable
    {
        [SerializeField] public string itemName;
        [SerializeField] public int weight { get; set; }
        
        public void OnSelect()
        {
            Debug.Log("Selected cabinet");
        }

        public void OnDeselect()
        {
            
        }

        public void OnHold()
        {
            
        }
    }
}