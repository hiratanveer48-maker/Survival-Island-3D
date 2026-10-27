using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    public GameObject campfirePrefab;
    public GameObject shelterPrefab;
    public Transform spawnPoint;

    public void CraftCampfire()
    {
        if (InventoryManager.Instance.HasResource("Wood", 5) && InventoryManager.Instance.HasResource("Stone", 2))
        {
            InventoryManager.Instance.ConsumeResource("Wood", 5);
            InventoryManager.Instance.ConsumeResource("Stone", 2);

            Instantiate(campfirePrefab, spawnPoint.position + spawnPoint.forward * 2f, Quaternion.identity);
            Debug.Log("Campfire Crafted successfully!");
        }
        else
        {
            Debug.Log("Not enough resources to craft Campfire!");
        }
    }

    public void CraftShelter()
    {
        if (InventoryManager.Instance.HasResource("Wood", 15) && InventoryManager.Instance.HasResource("Stone", 10))
        {
            InventoryManager.Instance.ConsumeResource("Wood", 15);
            InventoryManager.Instance.ConsumeResource("Stone", 10);

            Instantiate(shelterPrefab, spawnPoint.position + spawnPoint.forward * 3f, Quaternion.identity);
            Debug.Log("Shelter Crafted successfully!");
        }
        else
        {
            Debug.Log("Not enough resources to craft Shelter!");
        }
    }
}
