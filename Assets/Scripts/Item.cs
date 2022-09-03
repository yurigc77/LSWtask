using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new item",menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    public Sprite icon;
    public string title;

    [System.Serializable]   
    public enum Type
    {
        Hat,
        Glasses,
        Tshirt
    }

    public Type ItemType;
}
