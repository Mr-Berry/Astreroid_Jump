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
		SetNewScore(other);
		gameStates.setCamera();
		gameStates.setGameState(GameStates.STATES.GAMEOVER);
	}

	private void SetNewScore (Collider other) {
		int newScore = (int)other.GetComponent<ScoreTracker>().m_score;
		PlayerPrefs.SetInt("newScore", newScore);
	}
}
