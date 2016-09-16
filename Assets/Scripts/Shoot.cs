using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire")) {
			GameObject bullet = Instantiate(bulletPrefab);
			bullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector3.forward);
		}
	}
}
