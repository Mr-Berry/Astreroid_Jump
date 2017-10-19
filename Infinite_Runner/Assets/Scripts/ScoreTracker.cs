using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour {

	public Text scoreText;

	private float m_score;
	// Use this for initialization
	void Start () {
		m_score = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		m_score += Time.deltaTime;
	}

	public void AddBonus (int pointsToAdd = 1) {
		m_score += pointsToAdd;
		SetText();
	}

	private void SetText () {
		string newScoreText = "Score: " + (int)m_score;
		scoreText.text = newScoreText;
	}
}
