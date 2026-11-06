using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public Inventory inventory;

    [Header("Items")]
    public ItemData scrollData;
    public ItemData chestData;

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            Debug.Log("(Scroll) GameManager works");
            inventory.AddCollectedItem(scrollData);
        }
        if (Keyboard.current != null && Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            Debug.Log("(Chest) GameManager works");
            inventory.AddCollectedItem(chestData);
        }
    }
}