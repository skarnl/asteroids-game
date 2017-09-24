﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathExample : MonoBehaviour {
	Vector3 startPos;
 
	protected void Start() {
		startPos = transform.position;
	}
 
	protected void Update() {
		float distance = Mathf.Sin(Time.timeSinceLevelLoad);
		transform.position = startPos + Vector3.up * distance;
	}
}