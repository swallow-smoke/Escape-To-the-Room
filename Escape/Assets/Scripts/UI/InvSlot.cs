using Controller;
using Data.Items;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class InvSlot : UIBase, IDropHandler
    {
        [SerializeField] private Image icon;

        private int index;
        private ItemBase currentItem;

        public void SetIndex(int i)
        {
            index = i;
        }

        public void SetItem(ItemBase item)
        {
            currentItem = item;
            icon.sprite = item.sprite;
            icon.enabled = true;
        }

        public void Clear()
        {
            currentItem = null;
            icon.sprite = null;
            icon.enabled = false;
        }
        
        GameObject Icon()
        {
            if (transform.childCount > 0)
                return transform.GetChild(0).gameObject;
            else
                return null;
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (DragHandler.beingDragIcon == null) return;

            var drag = DragHandler.beingDragIcon.GetComponent<DragHandler>();
            var fromSlot = drag.startParent.GetComponent<InvSlot>();

            if (fromSlot == null) return;

            var temp = InventoryController.Instance.items[index];
            InventoryController.Instance.items[index] = InventoryController.Instance.items[fromSlot.index];
            InventoryController.Instance.items[fromSlot.index] = temp;
            
            InventoryPanel.RefreshInv();
        }
    }
}