using UnityEngine;
using System.Collections;

public class DebugBorder : MonoBehaviour {

	public GameObject player;

	// Update is called once per frame
	void FixedUpdate () {
		var dist = (player.transform.position - Camera.main.transform.position).z;

		var leftBorder = Camera.main.ViewportToWorldPoint(
		new Vector3(0, 0, dist)
		).x;

		var rightBorder = Camera.main.ViewportToWorldPoint(
		new Vector3(1, 0, dist)
		).x;

		var topBorder = Camera.main.ViewportToWorldPoint(
		new Vector3(0, 0, dist)
		).y;

		var bottomBorder = Camera.main.ViewportToWorldPoint(
		new Vector3(0, 1, dist)
		).y;

		Debug.Log(leftBorder);
	}
}
