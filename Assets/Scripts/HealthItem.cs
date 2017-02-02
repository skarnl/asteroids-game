using Managers;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int HealthAdded = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            HealthManager.Instance.AddHealth(HealthAdded);

            DestroyObject(gameObject);
        }
    }
}