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

    public void Initialize(ItemData itemData)
    {
        data = itemData;
        image.sprite = data.itemSprite;
        if (data.itemQuantity > 1)
        {
            quantityText.text = data.itemQuantity.ToString();
        }
        else
        {
            quantityText.text = "";
        }
    }

}