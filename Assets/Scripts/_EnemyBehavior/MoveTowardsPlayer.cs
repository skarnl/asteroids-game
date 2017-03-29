using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour {

    private GameObject player;
    public float speed = 5f;

    private Vector3 goal;

    public float RotationSpeed = 200f;

	// Use this for initialization
	void Start ()
	{
	    player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

	    if (goal != Vector3.zero) { // move towards last known position
	        float step = speed * Time.deltaTime;
	        transform.position = Vector3.MoveTowards(transform.position, goal, step);

	        if (Vector2.Distance(transform.position, goal) < float.Epsilon) {
	            goal = Vector3.zero;
	        }
	    }
	    else { // look around
	        transform.Rotate(Vector3.forward * (RotationSpeed * Time.deltaTime));
	    }
	}

    void FixedUpdate()
    {
        float distance = 1.2f;

        Debug.DrawRay(transform.position, transform.up * distance, Color.yellow);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, distance, 1 << LayerMask.NameToLayer("Player"));

        if (hit.collider != null) {

            print(hit.collider);
            print(hit.collider.IsTouchingLayers(LayerMask.NameToLayer("Player")));

            goal = hit.point;

            print("HIT!");
        }
    }
}
