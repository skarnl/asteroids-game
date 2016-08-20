using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rb;

	[Range(0, 30)]
	public float speed = 5;

	[Range(0, 20)]
	public float rotationSpeed = 5;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis("Horizontal");
		float vertical   = Input.GetAxis("Vertical");

		Debug.Log(horizontal);
		Debug.Log(horizontal * rotationSpeed * -1);
		Debug.Log(horizontal * rotationSpeed);
		Debug.Log("---");

		transform.Rotate(Vector3.forward, horizontal * rotationSpeed * -1);
		rb.AddRelativeForce(new Vector2(0, vertical * speed));
	}
}
