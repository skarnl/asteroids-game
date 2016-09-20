using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) {
        Health selfHealth = GetComponent<Health>();

        if (selfHealth) {
            selfHealth.TakeHit();
        }        

        Health otherHealth = coll.gameObject.GetComponent<Health>();

        if (otherHealth) {
            otherHealth.TakeHit();
        }        
    }
}