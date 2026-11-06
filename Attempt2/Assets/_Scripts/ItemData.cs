using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    public int itemQuantity = 1;
    public int stackSize = 99;
    public ItemType itemType;


    public enum ItemType
    {
        Item,
        Helmet,
        Chestplate,
        Leggings,
        Boots
    }

}

