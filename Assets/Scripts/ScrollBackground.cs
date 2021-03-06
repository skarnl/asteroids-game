﻿using UnityEngine;
using System.Collections;

public class ScrollBackground : MonoBehaviour {

	public float scrollDevider = 2f;

	private Material mat;

	void Start () {
		mat = GetComponent<MeshRenderer>().material;
	}

	// Update is called once per frame
	void Update () {
		Vector2 materialOffset = mat.mainTextureOffset; 

		materialOffset.x = transform.position.x / transform.localScale.x / scrollDevider;
		materialOffset.y = transform.position.y / transform.localScale.y / scrollDevider;

		mat.mainTextureOffset = materialOffset;
	}
}
