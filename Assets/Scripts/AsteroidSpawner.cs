using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AsteroidSpawner : MonoBehaviour {

	public GameObject asteroidPrefab;
	public GameObject player;

	private List<GameObject> asteroids;

	private Vector3 leftTop, rightTop, leftBottom, rightBottom;

	private Vector3 playerPosition;

	public float travelOffset = 4.0f;
	public float borderSpawnOffset = 4.0f;
	public int maxAsteroidsPerSpawn = 10;
	public float borderOffset = 1.5f;
	public float removeOffset = 3.0f;

	private bool firstTime = true;

	// Use this for initialization
	void Start () {
		asteroids = new List<GameObject>();

		SpawnInitialAsteroids();
	}

    private void SpawnInitialAsteroids()
    {
        bool firstTime = true;

		for (int i = 0; i < 2; i++)
		{
			RecalculateViewportBorders();

			if (firstTime) {
				float percentage = 0.5f;

				leftTop = new Vector3(leftTop.x * percentage, leftTop.y * percentage, leftTop.z);
				rightTop = new Vector3(rightTop.x * percentage, rightTop.y * percentage, rightTop.z);
				leftBottom = new Vector3(leftBottom.x * percentage, leftBottom.y * percentage, leftBottom.z);
				rightBottom = new Vector3(rightBottom.x * percentage, rightBottom.y * percentage, rightBottom.z);

				firstTime = false;
			}

			SpawnAsteroids("up");
			SpawnAsteroids("down");
			SpawnAsteroids("left");
			SpawnAsteroids("right");
		}
    }

    private void RecalculateViewportBorders()
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
		if (player == null) {
			return;
		}

		Rigidbody2D playerRigidBody2D = player.GetComponent<Rigidbody2D>();

		if (Vector2.Distance(player.transform.position, playerPosition) > travelOffset) {

			RecalculateViewportBorders();

			if (playerRigidBody2D.velocity.y > 0) { //GOING UP
				SpawnAsteroids("up");
			} else if (playerRigidBody2D.velocity.y < 0) { //GOING DOWN
				SpawnAsteroids("down");
			}

			if (playerRigidBody2D.velocity.x > 0) { //GOING RIGHT 
				SpawnAsteroids("right");
			} else if (playerRigidBody2D.velocity.x < 0) { //GOING LEFT
				SpawnAsteroids("left");
			}

			playerPosition = player.transform.position;
		}

		CleanUp();
	}

	private void SpawnAsteroids(string direction)
	{
		int maxAsteroids = UnityEngine.Random.Range(0, maxAsteroidsPerSpawn);

		for (int i = 0; i < maxAsteroids; i++) {
			GameObject asteroid = Instantiate(asteroidPrefab, GetSpawnLocation(direction), Quaternion.identity) as GameObject;
			asteroids.Add(asteroid);
		}
	}

	private Vector3 GetSpawnLocation(string direction) {

		switch(direction){
			case "right":
				return new Vector3(rightTop.x + UnityEngine.Random.Range(0, borderSpawnOffset), UnityEngine.Random.Range(leftTop.y + borderOffset, leftBottom.y - borderOffset), leftTop.z);
			case "left":
				return new Vector3(leftTop.x - UnityEngine.Random.Range(0, borderSpawnOffset), UnityEngine.Random.Range(leftTop.y + borderOffset, leftBottom.y - borderOffset), leftTop.z);
			case "up":
				return new Vector3(UnityEngine.Random.Range(leftTop.x - borderOffset, rightTop.x + borderOffset), leftTop.y + UnityEngine.Random.Range(0, borderSpawnOffset), leftTop.z);
			case "down":
				return new Vector3(UnityEngine.Random.Range(leftTop.x - borderOffset, rightTop.x + borderOffset), leftBottom.y - UnityEngine.Random.Range(0, borderSpawnOffset), leftTop.z);
		}

		return Vector3.zero;
	}

    private void CleanUp()
    {
		GameObject asteroid;

		List<GameObject> toBeRemoved = new List<GameObject>();

        for (int i = 0; i < asteroids.Count; i++)
		{
			asteroid = asteroids[i];
			
			if (asteroid == null) {
				asteroids.Remove(asteroid);
				continue;
			}

			Vector3 asteroidPosition = asteroid.transform.position;

			if (   asteroidPosition.x < leftTop.x - removeOffset
				|| asteroidPosition.x > rightTop.x + removeOffset
				|| asteroidPosition.y > leftTop.y + removeOffset
				|| asteroidPosition.y < leftBottom.y - removeOffset )
				{
					toBeRemoved.Add(asteroid);
				}
		}

		foreach (GameObject item in toBeRemoved)
		{
			asteroids.Remove(item);
			Destroy(item);
		}

		toBeRemoved.Clear();		
    }
}
