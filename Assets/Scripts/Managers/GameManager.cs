using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Prime31.MessageKit;
using UnityEngine.SceneManagement;
using Variables;

namespace Managers {

    /**
    *
    * This class handles all the global game related shizzle (showing modals etc)
    *
    */
    public class GameManager : Singleton<GameManager> {
        protected GameManager () {} // guarantee this will be always a singleton only - can't use the constructor!

        public GameObject healthPickupPrefab;
        public GameObject smokePrefab;
        
        private State state = State.start;
        private GameObject gameOverText;
        
        void Awake ()
        {
            RegisterForMessages();
            
            gameOverText = GameObject.Find("UI/GameOver");
            gameOverText.SetActive(false);
        }

        void Start()
        {
            this.setState(State.start);
        }

        private void RegisterForMessages()
        {
            MessageKit<GameObject>.addObserver(MessageTypes.gameObjectDestroyed, GameObjectDestroyedHandler);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                if (this.state == State.playing) {
                    this.setState(State.pause);
                } else if (this.state == State.pause) {
                    this.setState(State.playing);
                } else if (this.state == State.help) {
                    this.setState(State.pause);
                }
                else {
                    print("Pressed ESC, but State not updated since we aren't playing");
                }
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

            if (destroyedGameObject.tag == "Enemy") {
                AddPoints(Points.ENEMY_DESTROYED);
            }

            if (destroyedGameObject.tag == "HealthPickup") {
                GameObject healthAnimation = Instantiate(healthPickupPrefab, destroyedGameObject.transform.position, Quaternion.identity) as GameObject;
                Destroy(healthAnimation, 3);
            }

            if (destroyedGameObject.tag == "Player") {
                this.setState(State.gameOver);
            }
        }

        private void AddPoints(int points)
        {
            PointManager.Instance.AddPoints(points);
        }

        public State getState()
        {
            return this.state;
        }

        public void setState(State state)
        {
            print("GameManager::setState -> " + state);

            State oldState = this.state;
            this.state = state;

            this.HandleStateChange(oldState);

            if (this.state != State.quit) {
                MessageKit<State>.post(MessageTypes.gameStateChanged, oldState);
            }
        }
    
        private void HandleStateChange(State oldState)
        {            
            if (this.state != State.playing) {
                Time.timeScale = 0;

                switch (this.state) {
                    case State.quit:
                        Application.Quit();
                        break;

                    case State.help:
                        
                        break;
                        
                    case State.restart:
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                        break;
                        
                    case State.gameOver:
                        StartCoroutine(gameOverCoroutine());
                        break;

                }
            } else {
                Time.timeScale = 1;
            }
        }

        private void OnDestroy()
        {
            MessageKit<GameObject>.removeObserver(MessageTypes.gameObjectDestroyed, GameObjectDestroyedHandler);
        }
        
        private IEnumerator gameOverCoroutine()
        {
            gameOverText.SetActive(true);

            print("before 5 seconds");
            
            yield return new WaitForSecondsRealtime(5);

            print("after 5 seconds");
            
            this.setState(State.start);
        }
    }

}

