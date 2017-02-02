using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private void Awake()
    {
        Destroy(gameObject, 3);
    }

    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(Vector3.up * 100);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health otherHealth = other.gameObject.GetComponent<Health>();

        if (otherHealth) {
            otherHealth.TakeHit();
            Destroy(gameObject);
        }
    }
}
