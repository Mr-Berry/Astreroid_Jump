using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates : MonoBehaviour {

	public GameObject[] GameObjectStates;
	public Camera mainCamera;
	public LevelManager levelManager;
	public GameObject player;
	public enum STATES {MENU, PLAY, GAMEOVER, WIN, SCORE, NUMSTATES};
	private STATES state;
	private Vector3 cameraPos;

	// Use this for initialization
	void Start () {
		GameObjectStates[(int)state].SetActive(true);
		state = STATES.MENU;
		cameraPos = mainCamera.transform.position;
		setCamera();
	}
	
	// Update is called once per frame
	void Update () {
		HandleQuit();
	}

	public void setGameState (STATES newState) {
		STATES old = state;
		state = newState;
		GameObjectStates[(int)state].SetActive(true);
		SetInactive(old);
		if (state == STATES.PLAY) {
			levelManager.InitGame();
		} else if (state == STATES.SCORE) {
			GameObjectStates[(int)state].GetComponent<ScoreBoard>().UpdateScoreBoard();
		}
	}

	private void SetInactive (STATES old) {
		GameObjectStates[(int)old].SetActive(false);
	}

	public void setCamera () {
		mainCamera.transform.position = cameraPos;
	}

	private void HandleQuit () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			setGameState(GameStates.STATES.MENU);
		}
	}
}
