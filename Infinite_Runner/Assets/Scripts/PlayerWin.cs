using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour {

	public GameStates gameStates;

	public void UpdatePlayerPrefs (string playerName) {

		int newHighScore = PlayerPrefs.GetInt("newScore");

		if (newHighScore > PlayerPrefs.GetInt("HighScore0")) {

			PlayerPrefs.SetInt("HighScore4", PlayerPrefs.GetInt("HighScore3"));
			PlayerPrefs.SetInt("HighScore3", PlayerPrefs.GetInt("HighScore2"));
			PlayerPrefs.SetInt("HighScore2", PlayerPrefs.GetInt("HighScore1"));
			PlayerPrefs.SetInt("HighScore1", PlayerPrefs.GetInt("HighScore0"));
			PlayerPrefs.SetInt("HighScore0", newHighScore);
			PlayerPrefs.SetString("Name4", PlayerPrefs.GetString("Name3"));
			PlayerPrefs.SetString("Name3", PlayerPrefs.GetString("Name2"));
			PlayerPrefs.SetString("Name2", PlayerPrefs.GetString("Name1"));
			PlayerPrefs.SetString("Name1", PlayerPrefs.GetString("Name0"));
			PlayerPrefs.SetString("Name0", playerName);

		} else if (newHighScore > PlayerPrefs.GetInt("HighScore1")) {

			PlayerPrefs.SetInt("HighScore4", PlayerPrefs.GetInt("HighScore3"));
			PlayerPrefs.SetInt("HighScore3", PlayerPrefs.GetInt("HighScore2"));
			PlayerPrefs.SetInt("HighScore2", PlayerPrefs.GetInt("HighScore1"));
			PlayerPrefs.SetInt("HighScore1", newHighScore);
			PlayerPrefs.SetString("Name4", PlayerPrefs.GetString("Name3"));
			PlayerPrefs.SetString("Name3", PlayerPrefs.GetString("Name2"));
			PlayerPrefs.SetString("Name2", PlayerPrefs.GetString("Name1"));
			PlayerPrefs.SetString("Name1", playerName);

		} else if (newHighScore > PlayerPrefs.GetInt("HighScore2")) {

			PlayerPrefs.SetInt("HighScore4", PlayerPrefs.GetInt("HighScore3"));
			PlayerPrefs.SetInt("HighScore3", PlayerPrefs.GetInt("HighScore2"));
			PlayerPrefs.SetInt("HighScore2", newHighScore);
			PlayerPrefs.SetString("Name4", PlayerPrefs.GetString("Name3"));
			PlayerPrefs.SetString("Name3", PlayerPrefs.GetString("Name2"));
			PlayerPrefs.SetString("Name2", playerName);

		} else if (newHighScore > PlayerPrefs.GetInt("HighScore3")) {

			PlayerPrefs.SetInt("HighScore4", PlayerPrefs.GetInt("HighScore3"));
			PlayerPrefs.SetInt("HighScore3", newHighScore);
			PlayerPrefs.SetString("Name4", PlayerPrefs.GetString("Name3"));
			PlayerPrefs.SetString("Name3", playerName);

		} else {

			PlayerPrefs.SetInt("HighScore4", newHighScore);
			PlayerPrefs.SetString("Name4", playerName);

		}
		gameStates.setGameState(GameStates.STATES.SCORE);
	}
}
