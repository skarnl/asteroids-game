using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AsteroidSpawner : MonoBehaviour {

	public int startAsteroids = 6;
	public int maxAsteroids = 100;
	public GameObject asteroidPrefab;
	public GameObject player;

	private List<GameObject> asteroids;

	private Vector3 leftTop, rightTop, leftBottom, rightBottom;

	private Vector3 playerPosition;

	// Use this for initialization
	void Start () {

		DetermineBorders();

		asteroids = new List<GameObject>();

		for(int i = 0; i < startAsteroids; i++) {
			// GameObject asteroid = Instantiate(asteroidPrefab, new Vector3(UnityEngine.Random.Range(leftTop.x, rightTop.x), UnityEngine.Random.Range(leftTop.y, leftBottom.y), leftTop.z), Quaternion.identity) as GameObject;
			// asteroids.Add(asteroid);			
		}
	}

    private void DetermineBorders()
    {
        var dist = (player.transform.position - Camera.main.transform.position).z;

		leftTop = Camera.main.ViewportToWorldPoint(
		new Vector3(0, 1, dist)
		);

		rightTop = Camera.main.ViewportToWorldPoint(
		new Vector3(1, 1, dist)
		);

		leftBottom = Camera.main.ViewportToWorldPoint(
		new Vector3(0, 0, dist)
		);

		rightBottom = Camera.main.ViewportToWorldPoint(
		new Vector3(1, 0, dist)
		);
    }

    // Update is called once per frame
    void Update () {
		/**

		determine / ask the player direction

		store the current player position

		if current position > previous position + offst {
			spawn x asteroids just above/below the viewport
		}

		check asteroids on the opposing side if they need to be removed

		*/

		Rigidbody2D playerRigidBody2D = player.GetComponent<Rigidbody2D>();

		if (playerRigidBody2D.velocity.y > 0) { //GOING UP

			if (Vector2.Distance(player.transform.position, playerPosition) > 4) {

				DetermineBorders();

				for (int i = 0; i < 10; i++) {
					GameObject asteroid = Instantiate(asteroidPrefab, new Vector3(UnityEngine.Random.Range(leftTop.x - 1.5f, rightTop.x + 1.5f), leftTop.y + UnityEngine.Random.Range(0, 4), leftTop.z), Quaternion.identity) as GameObject;
					asteroids.Add(asteroid);
				}

				playerPosition = player.transform.position;
			}
			
		} else if (playerRigidBody2D.velocity.y < 0) { //GOING DOWN
			
		}

		if (playerRigidBody2D.velocity.x > 0) { //GOING RIGHT 
			if (Vector2.Distance(player.transform.position, playerPosition) > 4) {

				DetermineBorders();

				for (int i = 0; i < 10; i++) {
					GameObject asteroid = Instantiate(asteroidPrefab, new Vector3(rightTop.x + UnityEngine.Random.Range(0, 4), UnityEngine.Random.Range(leftTop.y + 1.5f, leftBottom.y - 1.5f), leftTop.z), Quaternion.identity) as GameObject;
					asteroids.Add(asteroid);
				}

				playerPosition = player.transform.position;
			}
		} else if (playerRigidBody2D.velocity.x < 0) { //GOING LEFT
			if (Vector2.Distance(player.transform.position, playerPosition) > 4) {

				DetermineBorders();

				for (int i = 0; i < 10; i++) {
					GameObject asteroid = Instantiate(asteroidPrefab, new Vector3(leftTop.x - UnityEngine.Random.Range(0, 4), UnityEngine.Random.Range(leftTop.y + 1.5f, leftBottom.y - 1.5f), leftTop.z), Quaternion.identity) as GameObject;
					asteroids.Add(asteroid);
				}

				playerPosition = player.transform.position;
			}
		}
	}
}
