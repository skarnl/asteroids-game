using UnityEngine;
using System.Collections;

public class DebugBorder : MonoBehaviour {

	public GameObject player;

	// Update is called once per frame
	void FixedUpdate () {
		DrawDebugLines();	
	}

	// Draw the outlines of the viewport
	void DrawDebugLines() {
		var dist = (player.transform.position - Camera.main.transform.position).z;

		var leftTop = Camera.main.ViewportToWorldPoint(
		new Vector3(0, 1, dist)
		);

		var rightTop = Camera.main.ViewportToWorldPoint(
		new Vector3(1, 1, dist)
		);

		var leftBottom = Camera.main.ViewportToWorldPoint(
		new Vector3(0, 0, dist)
		);

		var rightBottom = Camera.main.ViewportToWorldPoint(
		new Vector3(1, 0, dist)
		);

		Debug.DrawLine(leftTop, rightTop, Color.green);
		Debug.DrawLine(rightTop, rightBottom, Color.green);
		Debug.DrawLine(rightBottom, leftBottom, Color.green);
		Debug.DrawLine(leftBottom, leftTop, Color.green);	
	}
}
