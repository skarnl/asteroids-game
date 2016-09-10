using UnityEngine;
using System.Collections;
using System;

public class Health : MonoBehaviour {

	public int hitPoints;

	public void TakeHit(int damage = 1) {
		hitPoints -= damage;

		if (hitPoints <= 0) {
			Destroy(gameObject);
		}
	}
}
