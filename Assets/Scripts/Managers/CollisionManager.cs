﻿using UnityEngine;
using Prime31.MessageKit;

namespace Managers {

    /**
    * This class handles all the collision events, broadcasted by the CollisionReporter class
    */

    public class CollisionManager : Singleton<CollisionManager> {
        
        protected CollisionManager () {} // guarantee this will be always a singleton only - can't use the constructor!


        /**

        Manager to handle all the collisions for all the objects

        Objects do the detection, but broadcast it (using the MessageKit) to here

        Here we check what objects collided and handle the results

        bullet - asteroid
        bullet - enemy
        bullet - healthpack
        player - healthpack
        player - asteroid

*/
        public const int ASTEROID_HIT_DAMAGE = 100;
        public const int ENEMY_HIT_DAMAGE = 200;
        public const int PLAYER_HEALTH_INCREASE = 66;

        public void HandleCollision(GameObject gameObject, Collider2D other)
        {
            if (gameObject.CompareTag("Player")) {
                if (other.CompareTag("Asteroid")) {
                    // player bumps into the asteroid
                    gameObject.GetComponent<Health>().TakeHit(ASTEROID_HIT_DAMAGE);
                    other.GetComponent<Health>().TakeHit();
                    SpawnSmoke(gameObject.transform.position);
                } else if (other.CompareTag("Enemy")) {
                    // player bumps into the enemy
                    gameObject.GetComponent<Health>().TakeHit(ENEMY_HIT_DAMAGE);
                    other.GetComponent<Health>().TakeHit();
                    SpawnSmoke(gameObject.transform.position);
                } else if(other.CompareTag("HealthPickup")) { // player picks up health item
                    MessageKit<GameObject>.post(MessageTypes.gameObjectDestroyed, other.gameObject);
                    gameObject.GetComponent<Health>().Heal(PLAYER_HEALTH_INCREASE);
                    Destroy(other.gameObject);
                    
                }
            } else if (gameObject.CompareTag("Bullet")) {
                if (other.CompareTag("Asteroid") || other.CompareTag("Enemy")) {
                    other.GetComponent<Health>().TakeHit();
                    Destroy(gameObject);
                    SpawnSmoke(gameObject.transform.position);
                }
            }
        }

        private void SpawnSmoke(Vector3 location)
        {
            GameObject smokeAnimation = Instantiate(GameManager.Instance.smokePrefab, location, Quaternion.identity) as GameObject;
            Destroy(smokeAnimation, 3);
        }
    }
}