using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObjects : MonoBehaviour {

	public Transform generationPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter( Collision other) {
		Vector3 newPos = other.transform.position;
		newPos.x = generationPoint.position.x;
		other.transform.position = newPos;
	}
}
