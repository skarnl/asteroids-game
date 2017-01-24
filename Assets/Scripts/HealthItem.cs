using UnityEngine;
public class HealthItem : MonoBehaviour
{
    public float HealthAdded = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health heal = other.GetComponent<Health>();

        heal.AddHealth(HealthAdded);

        DestroyObject(gameObject);
    }
}