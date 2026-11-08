using NUnit.Framework.Interfaces;
using System.Collections.Generic;
using TMPro;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEditor.Progress;
public class Inventory : MonoBehaviour
{
    [Header("Items")]
    public List<Item> collectedItems = new List<Item>();
    public List<InventorySlot> allItemSlots = new List<InventorySlot>();
    private Item selectedItem;

    [Header("ItemData")]

    [Header("HeldItem")]
    public Item heldItem;
    public bool IsHoldingItem = false;
    
    [Header("UI")]
    public GameObject inventory;

    void Start()
    {

    }

    //Update is called once per frame
    void Update()
    {

        if (inventory.activeInHierarchy is true && IsHoldingItem)
        {
            heldItem.transform.position = Input.mousePosition;
        }

    }



    //public void AddCollectedItem(ItemData itemToAdd, int quantity)
    //{
    //    for (int i = 0; i < allItemSlots.Count; i++)
    //    {
    //        InventorySlot slot = allItemSlots[i];
    //        if (!slot.IsEmpty())
    //        {
    //            if ((slot.item.data.itemName == itemToAdd.itemName) && (slot.item.quantity < slot.item.data.stackSize))
    //            {
    //                if ((quantity + slot.item.quantity) <= slot.item.data.stackSize)
    //                {
    //                    slot.item.quantity += quantity;
    //                    slot.item.UpdateQuantity();
    //                    return;
    //                }
    //                if ((quantity + slot.item.quantity) > slot.item.data.stackSize)
    //                {
    //                    int space = slot.item.data.stackSize - slot.item.quantity;
    //                    slot.item.quantity += space;
    //                    slot.item.UpdateQuantity();
    //                    quantity -= space;
    //                }
    //            }
    //        }
    //        if (slot.IsEmpty())
    //        {
    //            slot.AddNewItem(itemToAdd, quantity);
    //            return;
    //        }
    //    }
    //    Debug.Log("Inventory Full");
    //}

    public void AddCollectedItem(ItemData itemToAdd, int quantity)
    {
        for (int i = 0; i < allItemSlots.Count; i++)
        {
            InventorySlot slot = allItemSlots[i];

            if (!slot.IsEmpty())
            {
                if (slot.item.data.itemName == itemToAdd.itemName &&
                    slot.item.quantity < slot.item.data.stackSize)
                {
                    if (quantity + slot.item.quantity <= slot.item.data.stackSize)
                    {
                        slot.item.quantity += quantity;
                        slot.item.UpdateQuantity();
                        return;
                    }
                    int space = slot.item.data.stackSize - slot.item.quantity;

                    slot.item.quantity += space;
                    slot.item.UpdateQuantity();
                    quantity -= space;
                }
            }
            if (slot.IsEmpty())
            {
                slot.AddNewItem(itemToAdd, quantity);
                return;
            }
        }
        Debug.Log("Inventory Full");
    }


    public void ShowDescription(Item item)
    {
        //item.descriptionContainer.enabled = true;
        // Update text
    }

    public void HideDescription(Item item)
    {
        //item.descriptionContainer.enabled = false;
    }

}
