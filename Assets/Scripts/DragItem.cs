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
    public Slots.SlotsType slotype;
    void Start()
    {
        GetComponent<Image>().sprite = item.icon;
    }

   public void OnBeginDrag(PointerEventData eventData)
    {
        ItemBeginDragged = gameObject;
        startPos = transform.position;
        startParent = transform.parent;
        Debug.Log(GetComponent<CanvasGroup>().ToString());
        
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
        if (item.ItemType.ToString()==slot.SlotType.ToString())
        {
            transform.SetParent(slotTransform);
        }
        else if(slot.SlotType.ToString()=="inventory")
        {
            transform.SetParent(slotTransform);
            if(item.origin=="shop")
            {
                item.origin = "inventory";
                GameController.instance.LooseMoney(item);
            }
      
        }
        else if(slot.SlotType.ToString()=="shop")
        {
            transform.SetParent(slotTransform);
            if(item.origin!="shop")
            {
                GameController.instance.GetMoney(item);
                item.origin = "shop";
            }

               
        }
    }
}
