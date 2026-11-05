using NUnit.Framework.Interfaces;
using System.Collections.Generic;
using TMPro;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEditor.Progress;
public class GameManager : MonoBehaviour
{
    [Header("Items")]
    public List<Item> collectedItems = new List<Item>();
    public Item itemPrefab;
    //private Item selectedItem;

    [Header("ItemData")]
    public ItemData scrollData;
    public ItemData chestData;

    [Header("UI")]
    public GameObject inventory;
    public Transform slotsContainer;
    public GameObject descriptionContainer;


    void Start()
    {

    }

    //Update is called once per frame
    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            AddItem(scrollData);
        }
        if (Keyboard.current != null && Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            AddItem(chestData);
        }
    }

    public void AddItem(ItemData itemToAdd)
    {
        Debug.Log("Collected!");
        Item item = Instantiate(itemPrefab, slotsContainer);
        item.gameManager = this;
        item.Initialize(itemToAdd);
        collectedItems.Add(item);
        item.descriptionContainer.enabled = false;
    }


    public void ToggleInventory()
    {
        Debug.Log("Shop button pressed");
        inventory.SetActive(!inventory.activeInHierarchy);
    }


    public void ShowDescription(Item item)
    {
        Debug.Log("Enabled desciption");
        item.descriptionContainer.enabled = true;
        TMP_Text textt = item.transform.Find("Description/Text (TMP)").GetComponent<TMP_Text>();
        //textt.text = item.data.itemName;

        if (textt != null)
        {
            textt.text = item.data.itemName;
            Debug.Log($"Text: {item.data.itemName}");
        }
        else
        {
            Debug.Log("Broken");
        }
    }

    public void HideDescription(Item item)
    {
        Debug.Log("Disabled description");
        item.descriptionContainer.enabled = false;
        TMP_Text textt = item.transform.Find("Description/Text (TMP)").GetComponent<TMP_Text>();
        if (textt != null)
        {
            textt.text = "";
            Debug.Log($"Text: {item.data.itemName}");
            Debug.Log($"Source: {textt}");
        }
        else
        {
            Debug.Log("Broken");
        }
    }

    //private void UpdateDescriptionPanel(Item item)
    //{
    //    Debug.Log("Updating pane...");
    //    //Transform parentTransform = item.descriptionContainer.transform.GetChild(0);
    //    //TextMeshPro text = parentTransform.GetComponentInChildren<TextMeshPro>();

    //    TMP_Text textt = item.transform.Find("Description/Text (TMP)").GetComponent<TMP_Text>();


    //    if (textt != null)
    //    {
    //        textt.text = item.data.itemName;
    //        Debug.Log($"Text: {item.data.itemName}");
    //    }
    //    else
    //    {
    //        Debug.Log("Broken");
    //    }
    //}
}
