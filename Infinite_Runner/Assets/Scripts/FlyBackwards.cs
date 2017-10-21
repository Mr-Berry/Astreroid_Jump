using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBackwards : MonoBehaviour {

private Rigidbody m_rb;

public float increment;
	// Use this for initialization
	void Start () {
		m_rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos = m_rb.transform.position;
		newPos.z -= increment;
		m_rb.transform.position = newPos;
	}
}
