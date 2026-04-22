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

        public void SetIndex(int i) => index = i;

        public void SetItem(ItemBase item)
        {
            if (item == null) return;

            if (icon.sprite == null) icon = GetComponent<Image>();
            
            currentItem = item;
            icon.sprite = item.sprite;
            icon.enabled = true;
        }

        public void Clear()
        {
            currentItem = null;
            if (icon.sprite != null)
            {
                icon.sprite = null;
                icon.enabled = false;
            }
        }

        GameObject Icon()
        {
            if (transform.childCount > 0)
                return transform.GetChild(0).gameObject;
            else return null;
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (DragHandler.beingDragIcon == null) return;

            var drag = DragHandler.beingDragIcon.GetComponent<DragHandler>();
            var fromSlot = drag.startParent.GetComponent<InvSlot>();

            if (fromSlot == null) return;

            var inventory = Managers.GameManager.Instance.InventoryController;
            (inventory.items[index], inventory.items[fromSlot.index]) = (inventory.items[fromSlot.index], inventory.items[index]);
            inventory.Refresh();
        }
    }
}