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
		setGameState(STATES.SCORE);
		cameraPos = mainCamera.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setGameState (STATES newState) {
		STATES old = state;
		state = newState;
		GameObjectStates[(int)state].SetActive(true);
		SetInactive(old);
	}

	private void SetInactive (STATES old) {
		GameObjectStates[(int)old].SetActive(false);
	}

	public void setCamera () {
		mainCamera.transform.position = cameraPos;
	}
}
