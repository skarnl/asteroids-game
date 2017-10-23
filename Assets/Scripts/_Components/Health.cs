using UnityEngine;
using System.Collections;
using System;
using Prime31.MessageKit;

public class Health : MonoBehaviour {

    public int Hitpoints {
        get { return hitPoints; }
        set
        {
            hitPoints = Math.Max(0, Math.Min(maxHitpoints, value));
        }
    }

    private int maxHitpoints;
    [SerializeField]
    private int hitPoints;

    private void Start() {
        maxHitpoints = hitPoints;
    }

    private void Update()
    {
		if (hitPoints <= 0) {
		    hitPoints = 0;
			MessageKit<GameObject>.post(MessageTypes.gameObjectDestroyed, gameObject);
		    Destroy(gameObject);
		}
    }

    public void TakeHit(int damage = 1) {
		hitPoints -= damage;
	}

    public void Heal(int additionalHitpoints)
    {
        hitPoints += additionalHitpoints;
    }
}
