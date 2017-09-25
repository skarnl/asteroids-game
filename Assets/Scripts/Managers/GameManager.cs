using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Prime31.MessageKit;

namespace Managers {

    /**
    *
    * This class handles all the global game related shizzle (showing modals etc)
    *
    */
    public class GameManager : Singleton<GameManager> {
        protected GameManager () {} // guarantee this will be always a singleton only - can't use the constructor!

        public GameObject healthPickupPrefab;
        
        void Awake ()
        {
            RegisterForMessages();
        }

        private void RegisterForMessages()
        {
            MessageKit<GameObject>.addObserver(MessageTypes.gameObjectDestroyed, GameObjectDestroyedHandler);
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.Escape)) {
                print("// PAUSE //");
            }
        }

        // TODO: move to ScoreController - weird place for this behavior - should be somewhere in a ScoreController or something like that
        // this class should only handle the global game related shizzle
        private void GameObjectDestroyedHandler(GameObject destroyedGameObject)
        {
            if (destroyedGameObject.tag == "Asteroid") {
                AddPoints(Points.ASTEROID_DESTROYED);

                LootDrop ld = destroyedGameObject.GetComponent<LootDrop>();

                if (ld)
                {
                    ld.Spawn(destroyedGameObject.transform.position);
                }
            }
            
            if (destroyedGameObject.tag == "HealthPickup") {
                GameObject healthAnimation = Instantiate(healthPickupPrefab, destroyedGameObject.transform.position, Quaternion.identity) as GameObject;
                Destroy(healthAnimation, 3);
            }
        }

        private void AddPoints(int points)
        {
            PointManager.Instance.AddPoints(points);
        }
    }

}

