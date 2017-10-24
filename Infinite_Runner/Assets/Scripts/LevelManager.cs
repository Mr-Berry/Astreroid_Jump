using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public int ambientCount;
	public GameObject player;
	public Transform generationPoint;
	public int spaceBetweenX;
	public int spaceBetweenY;
	public GameObject pickup;
	public Transform ambientParent;
	public Transform pickupParent;
	public GameObject[] a_asteroid;
	public GameObject[] w_asteroid;
	public static LevelManager Instance { get{ return m_instance;} }
	private Transform lastPlatformPos;
	private Vector3 playerStartPos;
	private GameObject newPlatform;
	private static LevelManager m_instance = null;
	private GameObject[] a_asteroids;
	private List<GameObject> w_asteroids = new List<GameObject>();
	// Use this for initialization
	private GameObject[] gameObjects;

	void Awake () {
		/*
		if (m_instance != null && m_instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			m_instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
		*/
	}

	private GameObject CreateNewWalkable () {
		GameObject temp = Instantiate(GetRandomAsteroid(w_asteroid));
		temp.transform.position = GetNewPosition();
		int randomint = Random.Range(3,6);
		Vector3 newScale = new Vector3(randomint,randomint,randomint);
		temp.transform.localScale = newScale;
		SpawnPickup(temp.transform.position);
		return temp;
	}

	private Vector3 GetNewPosition () {
		Vector3 pos = newPlatform.transform.position;
		int offsetX = spaceBetweenX + Random.Range(-10,10);
		int offsetY = spaceBetweenY + Random.Range(-10,10);
		pos.x += offsetX;
		if (pos.y + offsetY > 20) {
			pos.y -= offsetY;
		} else {
			pos.y += offsetY;
		}
		return pos;
	}

	private GameObject GetRandomAsteroid (GameObject[] array) { return array[Random.Range(0, array.Length)]; }

	private void InitA_Asteroids() {
		a_asteroids = new GameObject[ambientCount];

		for (int i = 0; i < ambientCount; i++) {
			GameObject newAsteroid = Instantiate(GetRandomAsteroid(a_asteroid));
			a_asteroids[i] = newAsteroid;
			a_asteroids[i].GetComponent<AmbientMovement>().moveSpeed = -1 * Random.Range(5,30);
			Vector3 pos = generationPoint.position;
			Vector2 range = new Vector2(-1 * generationPoint.position.x, generationPoint.position.x);
			pos.y += Random.Range(-50,20);
			pos.z += Random.Range(40,70);
			pos.x = Random.Range(range.x,range.y);
			a_asteroids[i].GetComponent<Transform>().position = pos;
			a_asteroids[i].GetComponent<RandomRotator>().tumble = Random.Range(0.5f, 2f);
			int scale = Random.Range(1,5);
			Vector3 newScale = new Vector3 (scale,scale,scale);
			a_asteroids[i].transform.localScale = newScale;
			a_asteroids[i].transform.parent = ambientParent;
		}
	}

	void Start () {
		playerStartPos = player.transform.position;
		newPlatform = Instantiate(w_asteroid[1]);
		lastPlatformPos = newPlatform.transform;
		w_asteroids.Add(newPlatform);
		newPlatform.transform.parent = this.transform;
		InitA_Asteroids();
	}

	// Update is called once per frame
	void Update () {
		if (generationPoint.position.x > lastPlatformPos.position.x) {			
			newPlatform = CreateNewWalkable();
			lastPlatformPos	= newPlatform.transform;
			w_asteroids.Add(newPlatform);
			newPlatform.transform.parent = this.transform;
		}
	}

	public void InitGame() {
		player.transform.position = playerStartPos;
		player.GetComponent<Rigidbody>().velocity = Vector3.zero;
		player.GetComponent<Player_Controller>().boosterFuel = 1f;
		player.GetComponent<ScoreTracker>().m_score = 0f;
	}

	private void SpawnPickup (Vector3 pos) {
		int chance = Random.Range(0, 10);
		if (chance == 0) {
		pos.y += 10;
		GameObject newPickup = Instantiate(pickup);
		newPickup.transform.position = pos;	
		newPickup.transform.parent = pickupParent;	
		Debug.Log("Here");	
		}
	}
}

