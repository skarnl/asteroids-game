using UnityEngine;
using System.Collections;
using Managers;

public class PlayerCollision : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other) {
        print("collision with: " + other.collider.tag);

        if (other.collider.CompareTag("Asteroid")) {
            HealthManager.Instance.SubstractHealth(HealthManager.ASTEROID_HIT_DAMAGE);
            other.gameObject.GetComponent<Health>().TakeHit();
        }
	}
}
