using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rb;
	Animator animator;

	[Range(0, 5)]
	public float speed = 2.5f;

	[Range(0, 7)]
	public float rotationSpeed = 5;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis("Horizontal");
		float vertical   = Input.GetAxis("Vertical");

		animator.SetBool("accelerate", (vertical != 0));

		transform.Rotate(Vector3.forward, horizontal * rotationSpeed * -1);
		rb.AddRelativeForce(new Vector2(0, vertical * speed));
	}
}
