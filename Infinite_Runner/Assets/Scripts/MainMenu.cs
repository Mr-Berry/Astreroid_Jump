using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public GameStates gameStates;

	public void StartGame() {
		gameStates.setGameState(GameStates.STATES.PLAY);
	}

	public void ExitGame() {
		Application.Quit();
	}
}
