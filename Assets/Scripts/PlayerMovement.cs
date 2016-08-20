using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rb;

	[Range(0, 30)]
	public float speed = 2;

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

		rb.AddForce(new Vector2(0, vertical * speed));
	}
}
