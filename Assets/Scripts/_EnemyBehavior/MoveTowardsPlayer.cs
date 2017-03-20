using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour {

    private GameObject player;
    private Vector3 velocity = Vector3.zero;
    public float dampTime = 5f;

	// Use this for initialization
	void Start ()
	{
	    player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	    Vector3 delta = player.transform.position - gameObject.transform.position;
	    Vector3 destination = transform.position + delta;
	    transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
	}
}
