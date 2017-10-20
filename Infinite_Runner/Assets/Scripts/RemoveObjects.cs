﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveObjects : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit (Collider other) {
		Component temp = other.GetComponent<Player_Controller>();
		if (temp == null) {
			DestroyObject(other.gameObject);
		}
	}
}
