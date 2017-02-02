using UnityEngine;

public class LootDrop : MonoBehaviour
{
    public GameObject[] LootPrefabs;

    public void Spawn(Vector3 location)
    {
        GameObject LootPrefab = LootPrefabs[Random.Range(0, LootPrefabs.Length - 1)];

        GameObject Loot = Instantiate(LootPrefab, location, Quaternion.identity) as GameObject;
//        Loot.transform.SetParent(gameObject.transform);
    }
}