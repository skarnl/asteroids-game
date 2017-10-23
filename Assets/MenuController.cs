using System.Collections;
using System.Collections.Generic;
using Managers;
using Prime31.MessageKit;
using UnityEngine;
using UnityEngine.UI;
using Variables;

public class MenuController : MonoBehaviour {

	private GameObject startButton;
	private GameObject restartButton;
	private GameObject helpButton;
	private GameObject helpBackButton;
	private GameObject helpText;
	private GameObject quitButton;
	private GameObject buttonGroup;
	
	public void Awake ()
	{
		buttonGroup = GameObject.Find("Menu/Buttons");
		startButton = GameObject.Find("Menu/Buttons/Start");
		restartButton = GameObject.Find("Menu/Buttons/Restart");
		helpButton = GameObject.Find("Menu/Buttons/Help");
		quitButton = GameObject.Find("Menu/Buttons/Quit");
		
		helpText = GameObject.Find("Menu/HelpText");
		helpBackButton = GameObject.Find("Menu/Back");
		
		MessageKit<State>.addObserver(MessageTypes.gameStateChanged, GameStateChangedHandler);
		
		startButton.GetComponent<Button>().onClick.AddListener(delegate { ButtonClickHandler(State.playing); });
		restartButton.GetComponent<Button>().onClick.AddListener(delegate { ButtonClickHandler(State.restart); });
		helpButton.GetComponent<Button>().onClick.AddListener(delegate { ButtonClickHandler(State.help); });
		quitButton.GetComponent<Button>().onClick.AddListener(delegate { ButtonClickHandler(State.quit); });
		helpBackButton.GetComponent<Button>().onClick.AddListener(delegate { ButtonClickHandler(State.pause); });
		
		helpText.SetActive(false);
		helpBackButton.SetActive(false);
		restartButton.SetActive(false);
	}

	private void ButtonClickHandler(State newState)
	{
		print("MenuController::ButtonClickHandler - " + newState);
		
		GameManager.Instance.setState(newState);
	}

	private void GameStateChangedHandler(State oldState)
	{
		State newState = GameManager.Instance.getState();
		print("MenuController::GameStateChangedHandler - State changed from " + oldState + " to " + newState);
		
		if (newState == State.playing) {
			this.gameObject.SetActive(false);
			
			startButton.SetActive(false);
			restartButton.SetActive(true);
		} else if (newState == State.help) {
			this.gameObject.SetActive(true);
			
			buttonGroup.SetActive(false);
			helpText.SetActive(true);
			helpBackButton.SetActive(true);
			
		} else if (newState == State.pause) {
			this.gameObject.SetActive(true);
			
			buttonGroup.SetActive(true);
			helpText.SetActive(false);
			helpBackButton.SetActive(false);
			
			startButton.SetActive(false);
			restartButton.SetActive(true);
		}
	}
}
