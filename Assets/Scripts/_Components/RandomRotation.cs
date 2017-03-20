using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour {

	[Range(0, 20)]
	public float rotationSpeed = 5;

	// Use this for initialization
	void Start () {

		GetComponent<Rigidbody2D>().AddTorque(Random.Range(-1f, 1f) * rotationSpeed, ForceMode2D.Force);
	}
}
