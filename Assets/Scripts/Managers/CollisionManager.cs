using UnityEngine;

namespace Managers {

    /**
    * This class handles all the collision events, broadcasted by the CollisionReporter class
    */

    public class CollisionManager : Singleton<CollisionManager>
    {
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
        public const int ASTEROID_HIT_DAMAGE = 250;
        public const int PLAYER_HEALTH_INCREASE = 66;

        public void HandleCollision(GameObject gameObject, Collider2D other)
        {
            if (gameObject.CompareTag("Player")) {
                if (other.CompareTag("Asteroid")) {
                    // player bumps into the asteroid
                    gameObject.GetComponent<Health>().TakeHit(ASTEROID_HIT_DAMAGE);
                    other.GetComponent<Health>().TakeHit();
                } else if(other.CompareTag("HealthPickup")) { // player picks up health item
                    gameObject.GetComponent<Health>().Heal(PLAYER_HEALTH_INCREASE);
                    Destroy(other.gameObject);
                }
            } else if (gameObject.CompareTag("Bullet")) {
                if (other.CompareTag("Asteroid")) {
                    other.GetComponent<Health>().TakeHit();
                    Destroy(gameObject);

//                    case other.CompareTag("")
                }
            }
        }
    }
}