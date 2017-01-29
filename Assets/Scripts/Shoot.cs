using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class Shoot : MonoBehaviour {

	public GameObject bulletPrefab;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
		    GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
		}
	}
}
