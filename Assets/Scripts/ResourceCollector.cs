using UnityEngine;

public class ResourceCollector : MonoBehaviour
{
    public enum ResourceType { Wood, Stone, Fruit }
    public ResourceType resourceType;
    public int resourceAmount = 3;
    public float interactionRange = 3.0f;
    
    private Transform player;

    void Start()
    {
        GameObject pObj = GameObject.FindWithTag("Player");
        if (pObj != null) player = pObj.transform;
    }

    public void Harvest()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= interactionRange)
        {
            if (InventoryManager.Instance != null)
            {
                InventoryManager.Instance.AddResource(resourceType.ToString(), resourceAmount);
            }
            Destroy(gameObject);
        }
    }
}
