using UnityEngine;
using System.Collections;
using System;
using Prime31.MessageKit;

public class Health : MonoBehaviour {

	public float hitPoints;

    private void Awake()
    {
//        hitPoints = Math.Round(hitPoints);
    }

    public void TakeHit(float damage = 1) {
		hitPoints -= damage;

		if (hitPoints <= 0) {
			MessageKit<GameObject>.post(MessageTypes.gameObjectDestroyed, gameObject);
		    Destroy(gameObject);
		}
	}

    public void AddHealth(float healthAdded)
    {
        hitPoints += healthAdded;
    }
}
