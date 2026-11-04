using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    public int itemQuantity = 1;
    public ItemType itemType;


    public enum ItemType
    {
        Item,
        Equiptment,
        Consumable
    }

}

