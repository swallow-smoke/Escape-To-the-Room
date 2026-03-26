using Controller;
using UI.Attributes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class InventoryPanel : UIBase
    {
        public static InventoryPanel instance;
        
        [Bind("InventoryExit"), SerializeField] private Button Exit;
        [Bind("Slots"), SerializeField] private Transform Slots;
        [SerializeField] InvSlot[] invSlots;

        protected override void Start()
        {
            base.Start();
            invSlots = new InvSlot[Slots.childCount];

            for (int i = 0; i < Slots.childCount; i++)
            {
                invSlots[i] = Slots.GetChild(i).GetComponent<InvSlot>();
                invSlots[i].SetIndex(i);
            }
            gameObject.SetActive(false);
        }

        public static void RefreshInv()
        {
            if (instance == null) return;

            var items = InventoryController.Instance.items;

            for (int i = 0; i < instance.invSlots.Length; i++)
            {
                if (i < items.Count)
                {
                    instance.invSlots[i].SetItem(items[i]);
                }
                else
                {
                    instance.invSlots[i].Clear();
                }
            }
        }
    }
}