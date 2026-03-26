using UI.Attributes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class InventoryPanel : UIBase
    {
        [Bind("InventoryExit"), SerializeField] private Button Exit;
        [Bind("Slots"), SerializeField] private Transform Slots;
        [SerializeField] InvSlot[] invSlots;

        protected override void Start()
        {
            base.Start();

            for (int i = 0; i < Slots.childCount; i++)
            {
                invSlots[i] = Slots.GetChild(i).GetComponent<InvSlot>();
            }
        }
    }
}