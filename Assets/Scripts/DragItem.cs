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
    [SerializeField]
    private ClothesSocket clothesSocket;
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
        if (item.ItemType.ToString()==slot.SlotType.ToString())//if gonna equip item
        {
            if (item.origin == "shop" && GameController.instance.Money>=item.price)//if item came from shop I need to pay
            {
                GameController.instance.LooseMoney(item);
                transform.SetParent(slotTransform);
                item.origin = "equip";
                if (clothesSocket != null && item.AnimationClips != null)
                {
                    clothesSocket.Equip(item.AnimationClips);
                }
            }
            else if(item.origin !="shop" )
            {
                transform.SetParent(slotTransform);
                item.origin = "equip";
                if (clothesSocket != null && item.AnimationClips != null)
                {
                    clothesSocket.Equip(item.AnimationClips);
                }
            }

          
            
        }
        else if(slot.SlotType.ToString()=="inventory")//if gonna storage item
        {
            if (item.origin == "shop" && GameController.instance.Money >= item.price)//if item came from shop I need to pay
            {
                GameController.instance.LooseMoney(item);
                transform.SetParent(slotTransform);
                item.origin = "inventory";
            }
            else if (item.origin == "equip")
            {
                if (clothesSocket != null && item.AnimationClips != null)
                {
                    clothesSocket.Dequip();
                }
                transform.SetParent(slotTransform);
                item.origin = "inventory";
            }
            else if(item.origin=="inventory")
            {
                transform.SetParent(slotTransform);
            }
                
      
        }
        else if(slot.SlotType.ToString()=="shop")//if gonna shop item
        {
            if(item.origin=="inventory")//if item did not came from shop I need to recive
            {
                GameController.instance.GetMoney(item);
            }
            else if(item.origin == "equip" )
            {
                GameController.instance.GetMoney(item);
                if (clothesSocket != null && item.AnimationClips != null)
                {
                    clothesSocket.Dequip();
                }
            }
            
            transform.SetParent(slotTransform);
            item.origin = "shop";
   
        }
    }

   
    }
