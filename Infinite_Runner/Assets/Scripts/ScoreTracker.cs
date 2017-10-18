using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour {

	private float m_score;
	// Use this for initialization
	void Start () {
		m_score = 0f;
	}
	
	// Update is called once per frame
	void Update () {

		m_score += Time.deltaTime;
		Debug.Log((int)Mathf.Floor(m_score));
	}

	public void AddBonus (int pointsToAdd) {
		m_score += pointsToAdd;
	}
}
