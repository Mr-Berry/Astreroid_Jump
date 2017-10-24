using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

	public Text[] HighScores;

	public GameStates gameStates;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void SetName(string name, int score, Text textBlock) {
		textBlock.text = name + "\t_\t " + score;
	}

	public void TransitionToMenu () {
		gameStates.setGameState(GameStates.STATES.MENU);
	}

	public void UpdateScoreBoard () {
		for (int i = 0; i < HighScores.Length; i++)	{
			SetName(PlayerPrefs.GetString("Name"+i), PlayerPrefs.GetInt("HighScore"+i), HighScores[i]);
			Debug.Log("Scoreboard" + PlayerPrefs.GetString("Name"+i));
		}
	}
}
