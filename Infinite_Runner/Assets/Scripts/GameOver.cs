using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	public GameStates gameStates;
	public Transform[] objects;
	private Transform[] objectsStartPositions = new Transform[5];
	private float timer = 0;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < objects.Length; i++) {
			objectsStartPositions[i] = objects[i];
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer/5 >= 1) {
			timer = 0;
			for (int i = 0; i < objects.Length; i++) {
				objects[i] = objectsStartPositions[i];
			}
			gameStates.setGameState(GameStates.STATES.SCORE);
		}
	}
}
