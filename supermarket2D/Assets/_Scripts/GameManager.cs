using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [Header("Items")]
    public List<Item> collectedItems = new List<Item>();
    public Item itemPrefab;
    private Item selectedItem;

    [Header("ItemData")]
    public ItemData data;

    [Header("UI")]
    public GameObject inventory;
    public GameObject descriptionContainer;


    void Start()
    {

    }

    //Update is called once per frame
    void Update()
    {

    }


    public void ToggleInventory()
    {
        Debug.Log("Shop button pressed");
        inventory.SetActive(!inventory.activeInHierarchy);
    }

    public void SelectItem(Item item)
    {
        selectedItem = item;
        descriptionContainer.SetActive(true);
        Debug.Log("Updated selected animal");

        UpdateDescriptionPanel(item);
    }

    private void UpdateDescriptionPanel(Item item)
    {
        descriptionContainer.GetComponentInChildren<TextMeshPro>().text = item.data.itemName;
    }
}
