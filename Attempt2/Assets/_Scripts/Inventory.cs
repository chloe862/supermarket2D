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
    
    [Header("UI")]
    public GameObject inventory;

    void Start()
    {

    }

    //Update is called once per frame
    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            ToggleInventory();
        }
    }

    public void AddCollectedItem(ItemData itemToAdd)
    {
        for (int i = 0; i < allItemSlots.Count; i++)
        {
            if (i <= allItemSlots.Count - 1)
            {
                Debug.Log($"If not at end... (i = {i})");
                InventorySlot slot = allItemSlots[i];
                Debug.Log($"slot = {allItemSlots[i]}");
                if (!slot.IsEmpty())
                {
                    Debug.Log("Slot not empty");
                    Debug.Log(slot.item.data.itemName);
                    if ((slot.item.data.itemName == itemToAdd.itemName) && (slot.item.data.itemQuantity <= slot.item.data.stackSize))
                    {
                        // if the item exists and is not at capacity
                        Debug.Log($"If the item exists and is not at capacity... (i = {i})");
                        if ((itemToAdd.itemQuantity + slot.item.data.itemQuantity) <= slot.item.data.stackSize)
                        {
                            slot.item.data.itemQuantity += itemToAdd.itemQuantity;
                            Debug.Log($"Item added to existing stack (i = {i})");
                            return;
                        }
                        if ((itemToAdd.itemQuantity + slot.item.data.itemQuantity) > slot.item.data.stackSize)
                        {
                            Debug.Log($"If over capacity add what it can... (i = {i})");
                            int space = slot.item.data.stackSize - slot.item.data.itemQuantity;
                            slot.item.data.itemQuantity += space;
                            itemToAdd.itemQuantity -= space;
                            // overflow should be handled 
                        }
                    }
                }
                Debug.Log($"Check if empty... (i = {i})");
                if (slot.IsEmpty())
                {
                    Debug.Log($"If empty add item to new slot (i = {i})");
                    slot.AddNewItem(itemToAdd); // handle item overflow
                    return;
                }
                //i += 1;
                Debug.Log($"Starting next iteration... (i = {i})");
            }
            Debug.Log("Inventory Full");
        }
    }


    public void ToggleInventory()
    {
        inventory.SetActive(!inventory.activeInHierarchy);
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
