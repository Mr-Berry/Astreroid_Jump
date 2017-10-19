using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Score : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.GetComponent<ScoreTracker>() != null) {
			other.gameObject.GetComponent<ScoreTracker>().AddBonus();
			Destroy(this.gameObject);
		}
	}
}
