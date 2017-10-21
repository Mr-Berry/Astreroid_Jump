using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

	public Text[] m_names;
	public int[] m_scores;
	public GameStates gameStates;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetName(string name, int score, int index) {
		m_scores[index] = score;
		string newString = name + " ___ " + score;
		m_names[index].text = newString;
	}

	public void TransitionToMenu () {
		gameStates.setGameState(GameStates.STATES.MENU);
	}
}
