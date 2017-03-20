using UnityEngine;
using Managers;

public class CollisionReporter : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D other) {
        CollisionManager.Instance.HandleCollision(gameObject, other.collider);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CollisionManager.Instance.HandleCollision(gameObject, other);
    }
}
