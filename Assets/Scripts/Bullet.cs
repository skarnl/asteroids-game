using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private void Awake()
    {
        Destroy(gameObject, 3);
    }

    private void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 100);
    }

    private void OnCollisionEnter(UnityEngine.Collision other)
    {
        Health selfHealth = GetComponent<Health>();

        if (selfHealth) {
            selfHealth.TakeHit();
        }

        Health otherHealth = other.gameObject.GetComponent<Health>();

        if (otherHealth) {
            otherHealth.TakeHit();
        }
    }
}
