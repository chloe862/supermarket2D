using UnityEditor.Search;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    [SerializeField] private Image image;
    public ItemData data;
    public InventorySlot slot;
    public TextMeshProUGUI quantityText;

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
        Debug.Log("Instantilizing");
        data = itemData;
        image.sprite = data.itemSprite;

    }

}