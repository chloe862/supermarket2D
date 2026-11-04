using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    public ItemData data;
    public GameManager gameManager;

    private void OnMouseDown()
    {
        Debug.Log("Item Selected");
        gameManager.SelectItem(this);
    }

    public void Initialize(ItemData itemData)
    {
        data = itemData;
        spriteRenderer.sprite = data.itemSprite;

    }
}