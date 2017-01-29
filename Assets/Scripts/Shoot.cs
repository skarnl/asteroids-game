using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class Shoot : MonoBehaviour {

	public GameObject bulletPrefab;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
		    GameObject bullet = Instantiate(bulletPrefab, gameObject.transform.position + gameObject.transform.up * 0.2f, transform.rotation);
		}
	}
}
