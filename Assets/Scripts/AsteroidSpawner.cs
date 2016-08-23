using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AsteroidSpawner : MonoBehaviour {

	public int startAsteroids = 6;
	public int maxAsteroids = 100;
	public GameObject asteroidPrefab;
	public GameObject player;

	private GameObject[] asteroids;

	private Vector3 leftTop, rightTop, leftBottom, rightBottom;

	// Use this for initialization
	void Start () {

		DetermineBorders();

		List<GameObject> asteroids = new List<GameObject>();

		for(int i = 0; i < startAsteroids; i++) {
			GameObject asteroid = Instantiate(asteroidPrefab, new Vector3(UnityEngine.Random.Range(leftTop.x, rightTop.x), UnityEngine.Random.Range(leftTop.y, leftBottom.y), leftTop.z), Quaternion.identity) as GameObject;
			asteroids.Add(asteroid);			
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

		




		*/




			 
	}
}
