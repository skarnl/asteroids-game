using Managers;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int HealthAdded = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        HealthManager.Instance.AddHealth(HealthAdded);

        DestroyObject(gameObject);
    }
}