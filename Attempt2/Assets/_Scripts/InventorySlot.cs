using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item item;
    //public TextMeshPro quantityText;
    public Inventory inventory;
    public Item itemPrefab;
    //public Button parent;

    //ItemData data; get itemdata from the item instead


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddNewItem(ItemData itemToAdd)
    {
        Debug.Log("Collected!");
        //Item item = Instantiate(itemPrefab, transform);
        item.slot = this;
        item.Initialize(itemToAdd);
    }

    public bool IsEmpty()
    {
        return (item.data is null);
    }

    public void SlotClicked()
    {
        if (IsEmpty() && inventory.heldItem is not null)
        {
            // if  holding item and slot empty --> do nothing
        }
        if (IsEmpty() && inventory.heldItem is null)
        {
            // if not holding item and slot empty --> place item
            item = inventory.heldItem;
            inventory.heldItem = null;
        }
        if (!IsEmpty() && inventory.heldItem is null)
        {
            // if not holding item and slot full --> pick up item
            inventory.heldItem = item;
            item = null;
        }
        if (!IsEmpty() && inventory.heldItem is not null)
        {
            // if holding item and slot full --> swap or combine items
            if (inventory.heldItem.data.itemName != item.data.itemName)
            {
                // if the items are not the same
                Item temp = inventory.heldItem;
                inventory.heldItem = item;
                item = temp;
                return;
            }
            // if the items are the same
            int space = item.data.stackSize - item.data.itemQuantity;
            item.data.itemQuantity += space;
            inventory.heldItem.data.itemQuantity -= space;

        }
    }
}
