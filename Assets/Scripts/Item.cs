using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName ="new item",menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    public Sprite icon;
    public string title;
    public int price;
    public string origin="shop";

    [System.Serializable]   
    public enum Type
    {
        Hat,
        Glasses,
        Tshirt
    }

    public Type ItemType;




}
