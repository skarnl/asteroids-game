using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Prime31.MessageKit;

public class GameManager : Singleton<GameManager> {
	protected GameManager () {} // guarantee this will be always a singleton only - can't use the constructor!
 
	void Awake ()
	{
		RegisterForMessages();
	}

    private void RegisterForMessages()
    {
        MessageKit<GameObject>.addObserver(MessageTypes.gameObjectDestroyed, GameObjectDestroyedHandler);
    }

    private void GameObjectDestroyedHandler(GameObject destroyedGameObject)
    {
        if (destroyedGameObject.tag == "Asteroid") {
			AddPoints(Points.ASTEROID_DESTROYED);
		}
    }

    private void AddPoints(int points)
    {
        PointManager.Instance.AddPoints(points);
    }
}