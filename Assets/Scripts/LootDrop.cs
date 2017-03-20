using UnityEngine;

public class LootDrop : MonoBehaviour
{
    public GameObject[] LootPrefabs;

    public void Spawn(Vector3 location)
    {
        GameObject RandomLootPrefab = LootPrefabs[Random.Range(0, LootPrefabs.Length - 1)];

        GameObject Loot = Instantiate(RandomLootPrefab, location, Quaternion.identity) as GameObject;
    }
}