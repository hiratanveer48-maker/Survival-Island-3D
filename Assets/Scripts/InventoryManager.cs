using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    private Dictionary<string, int> inventory = new Dictionary<string, int>();

    [Header("UI References")]
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI stoneText;
    public TextMeshProUGUI fruitText;
    public TextMeshProUGUI coinText;

    private int coins = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddResource(string resourceName, int amount)
    {
        if (inventory.ContainsKey(resourceName))
        {
            inventory[resourceName] += amount;
        }
        else
        {
            inventory[resourceName] = amount;
        }
        UpdateUI();
    }

    public bool HasResource(string resourceName, int amount)
    {
        return inventory.ContainsKey(resourceName) && inventory[resourceName] >= amount;
    }

    public void ConsumeResource(string resourceName, int amount)
    {
        if (HasResource(resourceName, amount))
        {
            inventory[resourceName] -= amount;
            UpdateUI();
        }
    }

    public int GetResourceCount(string resourceName)
    {
        return inventory.ContainsKey(resourceName) ? inventory[resourceName] : 0;
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (woodText != null) woodText.text = "Wood: " + GetResourceCount("Wood");
        if (stoneText != null) stoneText.text = "Stone: " + GetResourceCount("Stone");
        if (fruitText != null) fruitText.text = "Fruit: " + GetResourceCount("Fruit");
        if (coinText != null) coinText.text = "Coins: " + coins;
    }
}
