using UnityEngine;
using System.Collections;
using System;
using Prime31.MessageKit;

public class Health : MonoBehaviour {

	public int hitPoints;

    private void Update()
    {
		if (hitPoints <= 0) {
			MessageKit<GameObject>.post(MessageTypes.gameObjectDestroyed, gameObject);
		    Destroy(gameObject);
		}
    }

    public void TakeHit(int damage = 1) {
		hitPoints -= damage;
	}
}
