﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour {

    private GameObject player;
    public float speed = 5f;

    private Vector3 goal;

    public float RotationSpeed = 200f;

    public float distance = 1.2f;

	// Use this for initialization
	void Start ()
	{
	    player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	    if (goal != Vector3.zero) { // move towards last known position
		    
		    Debug.DrawLine(transform.position, goal, Color.cyan);
		    
	        float step = speed * Time.deltaTime;
	        transform.position = Vector3.MoveTowards(transform.position, goal, step);

	        //find the vector pointing from our position to the target
	        Vector3 _direction = (goal - transform.position);

	        //create the rotation we need to be in to look at the target
	        Quaternion _lookRotation = Quaternion.LookRotation(_direction, Vector3.back);
	        _lookRotation.x = 0;
	        _lookRotation.y = 0;

	        //rotate us over time according to speed until we are in the required rotation
	        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * 100f);

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
	    Debug.DrawLine(transform.position, transform.position + (transform.up * distance), Color.magenta);

	    var rotatedLine = Quaternion.Euler(0, 0, 45) * transform.up * distance;
	    Debug.DrawLine(transform.position, transform.position + rotatedLine, Color.yellow);
	    
	    var rotatedLine2 = Quaternion.Euler(0, 0, -45) * transform.up * distance;
	    Debug.DrawLine(transform.position, transform.position + rotatedLine2, Color.yellow);
	    
        if (Vector3.Distance(player.transform.position, transform.position) <= distance) {
            var playerDirection = player.transform.position - transform.position;

            var angle = Vector3.Angle(playerDirection, transform.up);

            if (angle < 45f) {
                goal = player.transform.position;
            }
        }

    }
}
