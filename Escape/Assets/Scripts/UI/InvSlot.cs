using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class InvSlot : UIBase, IDropHandler
    {
        GameObject Icon()
        {
            if (transform.childCount > 0)
                return transform.GetChild(0).gameObject;
            else
                return null;
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (Icon() == null)
            {
                DragHandler.beingDragIcon.transform.SetParent(transform);
                DragHandler.beingDragIcon.transform.position = transform.position;
            }
        }
    }
}