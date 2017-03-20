using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private void Awake()
    {
        // Destroy yourself after 3 seconds
        Destroy(gameObject, 3);
    }

    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(Vector3.up * 100);
    }
}
