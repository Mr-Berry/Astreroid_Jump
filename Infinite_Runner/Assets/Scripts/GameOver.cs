using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	public GameStates gameStates;
	public GameObject[] objects;
	private Vector3[] objectsStartPositions = new Vector3[5];
	private float timer = 0;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < objects.Length; i++) {
			objectsStartPositions[i] = objects[i].transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer/5 >= 1) {
			timer = 0;
			for (int i = 0; i < objects.Length; i++) {
				objects[i].transform.position = objectsStartPositions[i];
			}
			SetNewHighScore();
		}
	}

	private void SetNewHighScore () {
		int playerScore = PlayerPrefs.GetInt("newScore");

		if (PlayerPrefs.HasKey("HighScore0")) {
			if (playerScore >= PlayerPrefs.GetInt("HighScore4")) {
				gameStates.setGameState(GameStates.STATES.WIN);
			} else {
				gameStates.setGameState(GameStates.STATES.SCORE);				
			}
		} else {
			InitPlayerPrefs();
			gameStates.setGameState(GameStates.STATES.WIN);			
		}
	}

	private void InitPlayerPrefs() {
		PlayerPrefs.SetInt("HighScore0", 0);
		PlayerPrefs.SetInt("HighScore1", 0);
		PlayerPrefs.SetInt("HighScore2", 0);
		PlayerPrefs.SetInt("HighScore3", 0);
		PlayerPrefs.SetInt("HighScore4", 0);
		PlayerPrefs.SetString("Name0", "Dev");
		PlayerPrefs.SetString("Name1", "Dev");
		PlayerPrefs.SetString("Name2", "Dev");
		PlayerPrefs.SetString("Name3", "Dev");
		PlayerPrefs.SetString("Name4", "Dev");
	}
}
