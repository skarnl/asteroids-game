using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour {

	public int maxAsteroids = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		 Debug.DrawLine(Vector3.zero, new Vector3(1, 0, 0), Color.red);		 
	}
}
