using UnityEditor.Search;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private Image image;
    public ItemData data;
    public GameManager gameManager;
    public Image descriptionContainer;

    public void ShowDesciption()
    {
        Debug.Log(this);
        Debug.Log(gameManager);
        gameManager.ShowDescription(this);
    }

    public void HideDesciption()
    {
        gameManager.HideDescription(this);
    }

    public void Initialize(ItemData itemData)
    {
        Debug.Log("Instantilizing");
        data = itemData;
        image.sprite = data.itemSprite;

    }

}