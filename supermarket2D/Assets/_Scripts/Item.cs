using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private Image image;
    public ItemData data;
    public GameManager gameManager;

    private void OnMouseDown()
    {
        Debug.Log("Item Selected");
        gameManager.SelectItem(this);
    }

    public void Initialize(ItemData itemData)
    {
        Debug.Log("Instantilizing");
        data = itemData;
        image.sprite = data.itemSprite;

    }

}