using UnityEditor.Search;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    public Image image;
    public ItemData data;
    public InventorySlot slot;
    public TextMeshProUGUI quantityText;
    public int quantity;

    public void Start()
    {
        //image = GetComponent<Image>();
    }

    public void ShowDesciption()
    {
        //inventory.ShowDescription(this);
    }

    public void HideDesciption()
    {
        //inventory.HideDescription(this);
    }

    public void Initialize(ItemData itemData, InventorySlot parent)
    {
        data = itemData;
        image.sprite = data.itemSprite;
        slot = parent;
        UpdateQuantity();
    }

    public void UpdateQuantity()
    {
        if (quantity > 1)
        {
            quantityText.text = quantity.ToString();
        }
        else
        {
            quantityText.text = "";
        }
    }

}