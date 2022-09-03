using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : MonoBehaviour,IBeginDragHandler, IEndDragHandler,IDragHandler
{
    public static GameObject ItemBeginDragged;
    Vector3 startPos;
    Transform startParent;
    public Item item;
    void Start()
    {
        GetComponent<Image>().sprite = item.icon;
    }

   public void OnBeginDrag(PointerEventData eventData)
    {
        ItemBeginDragged = gameObject;
        startPos = transform.position; 
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ItemBeginDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == startParent)
        {
            transform.position = startPos;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    
    public void SetParent(Transform slotTransform, Slots slot)
    {

       
        if (item.ItemType.ToString()==slot.SlotType.ToString()|| item.ItemType.ToString() == "inventory")
        {
            transform.SetParent(slotTransform);
        }
        else 
        {
            transform.SetParent(slotTransform);
        }
    }
}
