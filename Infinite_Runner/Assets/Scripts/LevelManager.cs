using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public int ambientCount;
	public GameObject player;
	public Transform generationPoint;
	public int spaceBetween;
	private Transform lastPlatformPos;
	private GameObject newPlatform;
	private static LevelManager m_instance = null;
	public static LevelManager Instance { get{ return m_instance;} }
	public GameObject[] a_asteroid;
	private GameObject[] a_asteroids;
	private List<GameObject> w_asteroids = new List<GameObject>();
	public GameObject[] w_asteroid;
	private int widthSml;
	private int widthMed;
	private int widthLrg;
	// Use this for initialization
	private GameObject[] gameObjects;

	void Awake () {
		if (m_instance != null && m_instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			m_instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
	void Start () {
		newPlatform = Instantiate(w_asteroid[0]);
		lastPlatformPos = newPlatform.transform;
		InitA_Asteroids();
	}

	public void RestartLevel () {
	// accessable from anywhere

	}
	
	// Update is called once per frame
	void Update () {
		if (generationPoint.position.x > lastPlatformPos.position.x) {			
			newPlatform = CreateNewWalkable();
			lastPlatformPos	= newPlatform.transform;
			w_asteroids.Add(newPlatform);
		}
	}

	private void InitA_Asteroids() {
		a_asteroids = new GameObject[ambientCount];

		for (int i = 0; i < ambientCount; i++) {
			GameObject newAsteroid = Instantiate(GetRandomAsteroid(a_asteroid));
			a_asteroids[i] = newAsteroid;
			a_asteroids[i].GetComponent<AmbientMovement>().m_moveSpeed = -1 * Random.Range(5,30);
			Vector3 pos = generationPoint.position;
			Vector2 range = new Vector2(-1 * generationPoint.position.x, generationPoint.position.x);
			pos.y += Random.Range(-30,30);
			pos.z += Random.Range(20,50);
			pos.x = Random.Range(range.x,range.y);
			a_asteroids[i].GetComponent<Transform>().position = pos;
			a_asteroids[i].GetComponent<RandomRotator>().tumble = Random.Range(0.5f, 2f);
			int scale = Random.Range(1,5);
			Vector3 newScale = new Vector3 (scale,scale,scale);
			a_asteroids[i].transform.localScale = newScale;
		}
	}

	private GameObject GetRandomAsteroid (GameObject[] array) { return array[Random.Range(0, array.Length)]; }

	private GameObject CreateNewWalkable () {
		GameObject temp = Instantiate(GetRandomAsteroid(w_asteroid));
		temp.transform.position = GetNewPosition();
		int randomint = Random.Range(3,6);
		Vector3 newScale = new Vector3(randomint,randomint,randomint);
		temp.transform.localScale = newScale;
		return temp;
	}

	private Vector3 GetNewPosition () {
			Vector3 pos = newPlatform.transform.position;
			int offset = spaceBetween + Random.Range(-10,10);
			pos.x += offset;
			return pos;
	}
}

