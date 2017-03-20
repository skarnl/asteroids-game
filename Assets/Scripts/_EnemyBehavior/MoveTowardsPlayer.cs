using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour {

    private GameObject player;
    public float speed = 5f;

	// Use this for initialization
	void Start ()
	{
	    player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	    float step = speed * Time.deltaTime;
	    transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, step);
	}
}
