using NUnit.Framework.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item item;
    public Inventory inventory;
    public Item itemPrefab;


    public void AddNewItem(ItemData itemToAdd, int quantity)
    {
        Item newItem = Instantiate(itemPrefab, transform);
        item = newItem;
        Debug.Log(item);
        //Debug.Log(item.data);
        //Debug.Log(item.image.sprite);
        newItem.slot = this;
        newItem.Initialize(itemToAdd, this);
        newItem.quantity = quantity;
        newItem.UpdateQuantity();
    }

    public bool IsEmpty()
    {
        return (item is null);
    }

    public void SlotClicked()
    {
        //Debug.Log($"Clicked slot: {gameObject.name}");
        //Debug.Log($"item == null ? {item == null}");
        Debug.Log($"item = {item}");


        if (IsEmpty() && !inventory.IsHoldingItem)
        {
            // if not holding item and slot empty --> do nothing
            //Debug.Log("Slot: empty    Held: null");
        }
        if (IsEmpty() && inventory.IsHoldingItem)
        {
            // if holding item and slot empty --> place item
            //Debug.Log("Slot: empty    Held: not null");
            Debug.Log($"Placing item: {inventory.heldItem.data.itemName}");
            AddNewItem(inventory.heldItem.data, inventory.heldItem.quantity);
            inventory.heldItem.gameObject.SetActive(false);
            inventory.IsHoldingItem = false;
            Debug.Log($"Is holding item: {inventory.IsHoldingItem}");
            UpdateHeldItem();
        }
        if (!IsEmpty() && !inventory.IsHoldingItem)
        {
            // if not holding item and slot full --> pick up item
            //Debug.Log("Slot: filled    Held: empty");
            inventory.heldItem.data = item.data;
            inventory.heldItem.image.sprite = item.image.sprite;
            inventory.heldItem.quantity = item.quantity;
            inventory.heldItem.UpdateQuantity();

            inventory.IsHoldingItem = true;
            Destroy(item.gameObject);
            item = null;

        }
        //if (!IsEmpty() && inventory.IsHoldingItem)
        //{
        //    // if holding item and slot full --> swap or combine items
        //    //Debug.Log("Slot: filled    Held: not null");
        //    if (inventory.heldItem.data.itemName != item.data.itemName)
        //    {
        //        // if the items are not the same
        //        Item temp = inventory.heldItem;
        //        item = temp;
        //        inventory.IsHoldingItem = true;
        //        UpdateHeldItem();
        //        return;
        //    }
        //    // if the items are the same
        //    int space = item.data.stackSize - item.quantity;
        //    item.quantity += space;
        //    inventory.heldItem.quantity -= space;

        //}
    }
    public void UpdateHeldItem()
    {
        if (inventory.IsHoldingItem)
        {
            inventory.heldItem.data = item.data;
            inventory.heldItem.image.sprite = item.data.itemSprite;
            inventory.heldItem.quantity = item.quantity;
            inventory.heldItem.UpdateQuantity();
            inventory.heldItem.gameObject.SetActive(true);
        }
        else
        {
            //inventory.heldItem.gameObject.SetActive(false);
        }
    }

    public void UpdateItem(Item sourceItem)
    {
        item.data = sourceItem.data;
        item.image.sprite = sourceItem.image.sprite;
        item.quantity = sourceItem.quantity;

        item.UpdateQuantity();
    }
}
