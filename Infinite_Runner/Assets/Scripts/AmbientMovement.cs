using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientMovement : MonoBehaviour {

	public float m_moveSpeed;
	private Transform m_tf;
	// Use this for initialization
	void Start () {
		m_tf = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos = m_tf.position;
		newPos.x += m_moveSpeed * Time.deltaTime;
		m_tf.position = newPos;
	}
}
