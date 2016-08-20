using UnityEngine;
using System.Collections;

public class RandomMovement : MonoBehaviour {

	[Range(0, 30)]
	public float speed = 5;

	// Use this for initialization
	void Start () {

		Rigidbody2D rb = GetComponent<Rigidbody2D>();

		rb.AddForce(new Vector2(Random.Range(-1f, 1f) * speed, Random.Range(-1f, 1f) * speed));
	}
}
