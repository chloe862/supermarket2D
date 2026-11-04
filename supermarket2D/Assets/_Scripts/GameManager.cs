using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class GameManager : MonoBehaviour
{
    [Header("Items")]
    public List<Item> collectedItems = new List<Item>();
    public Item itemPrefab;
    private Item selectedItem;

    [Header("ItemData")]
    public ItemData scrollData;

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
    }

    public void AddItem(ItemData itemToAdd)
    {
        Debug.Log("Collected!");
        Item item = Instantiate(itemPrefab, slotsContainer);
        item.gameManager = this;
        item.Initialize(itemToAdd);
        collectedItems.Add(item);
    }

    //private void BuyAnimal(AnimalData newAnimal)
    //{
    //        Animal animal = Instantiate(animalPrefab);
    //        animal.gameManager = this;
    //        animal.Initialize(variants[3]);
    //        ownedAnimals.Add(animal);
    //}

    //public void BuyCow()
    //{
    //    BuyAnimal(whiteCowData);
    //}


    public void ToggleInventory()
    {
        Debug.Log("Shop button pressed");
        inventory.SetActive(!inventory.activeInHierarchy);
    }

    public void SelectItem(Item item)
    {

        if (selectedItem == item)
        {
            selectedItem = null;
            //selectedItem.descriptionContainer.SetActive(false);
            return;
        }

        selectedItem = item;
        //selectedItem.descriptionContainer.SetActive(true)
        Debug.Log("Updated selected item");

        UpdateDescriptionPanel(item);
    }

    private void UpdateDescriptionPanel(Item item)
    {
        //item.descriptionContainer.GetComponentInChildren<TextMeshPro>().text = item.data.itemName;
    }
}
