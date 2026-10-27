using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static void SaveGame(Vector3 playerPos, int health, int coins)
    {
        PlayerPrefs.SetFloat("PosX", playerPos.x);
        PlayerPrefs.SetFloat("PosY", playerPos.y);
        PlayerPrefs.SetFloat("PosZ", playerPos.z);
        PlayerPrefs.SetInt("PlayerHealth", health);
        PlayerPrefs.SetInt("PlayerCoins", coins);
        PlayerPrefs.Save();
        Debug.Log("Game Saved Successfully.");
    }

    public static void LoadGame(GameObject player, out int health, out int coins)
    {
        if (PlayerPrefs.HasKey("PosX"))
        {
            float x = PlayerPrefs.GetFloat("PosX");
            float y = PlayerPrefs.GetFloat("PosY");
            float z = PlayerPrefs.GetFloat("PosZ");
            player.transform.position = new Vector3(x, y, z);
        }
        health = PlayerPrefs.GetInt("PlayerHealth", 100);
        coins = PlayerPrefs.GetInt("PlayerCoins", 0);
        Debug.Log("Game Loaded Successfully.");
    }
}
