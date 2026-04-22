using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : UIBase, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static GameObject beingDragIcon;
    private Vector3 startPos;
    
    [SerializeField] private Transform onDragParent;
    [SerializeField] public Transform startParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        beingDragIcon = gameObject;

        startPos = transform.position;
        startParent = transform.parent;

        GetComponent<CanvasGroup>().blocksRaycasts = false;
        transform.SetParent(onDragParent, true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        beingDragIcon = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (transform.parent == onDragParent)
        {
            transform.position = startPos;
            transform.SetParent(startParent);
        }
    }
}