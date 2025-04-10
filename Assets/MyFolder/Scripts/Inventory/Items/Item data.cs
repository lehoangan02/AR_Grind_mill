using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class ItemData : ScriptableObject
{
    public TileBase tile;
    public Sprite image;
    public ItemType type;
    
    public static Dictionary<String, ItemType> stringToItemType = new Dictionary<String, ItemType>()
    {
        {"Rice basket", ItemType.RiceBasket},
        {"Watermelon slice", ItemType.WatermelonSlice},
    };

}

public enum ItemType : int
{
    RiceBasket = 0,
    WatermelonSlice = 1,
}