using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

	public GameStates gameStates;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit (Collider other) {
		gameStates.setCamera();
		gameStates.setGameState(GameStates.STATES.GAMEOVER);
	}

}
