using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientMovement : MonoBehaviour {

	public int moveSpeed = -5;
	static private float difficulty = 1;
	private Transform m_tf;
	// Use this for initialization
	void Start () {
		m_tf = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos = m_tf.position;
		newPos.x += (moveSpeed * difficulty) * Time.deltaTime;
		m_tf.position = newPos;
	}

	public void InceaseSpeed () {
		difficulty *= 1.02f;
	}
}
