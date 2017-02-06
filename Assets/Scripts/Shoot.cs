using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class Shoot : MonoBehaviour {

	public GameObject bulletPrefab;

    private bool waitingForDelay = false;

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space)) {
		    if (!waitingForDelay) {
                waitingForDelay = true;
                StartCoroutine(ShootBullet());
		    }
		}
	}

    private IEnumerator ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, gameObject.transform.position + gameObject.transform.up * 0.2f, transform.rotation);
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());

        yield return new WaitForSeconds(0.2f);
        waitingForDelay = false;
    }
}
