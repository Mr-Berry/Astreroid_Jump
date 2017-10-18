using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

	public float speed;
	public float jumpSpeed;
	public Camera mainCamera;
	private float horizontalMovement;
	private Vector3 cameraDist;
	private Rigidbody myRigidbody;
	private Animator myAnimator;
	private bool facingRight;
	private bool isJumping;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody>();
		myAnimator = GetComponent<Animator>();
		facingRight = true;
		isJumping = false;
		SetCameraDistance();
	}
	
	void Update () {

	}
	// Update is called once per frame
	void FixedUpdate () {
		horizontalMovement = Input.GetAxis("Horizontal");
		if (Input.GetKeyDown(KeyCode.Space) && !isJumping) {
			isJumping = true;
		}
		mainCamera.transform.position = new Vector3 (mainCamera.transform.position.x, GetComponent<Transform>().position.y, mainCamera.transform.position.z);
		HandleMovement();
	}

	private void Flip (float horizontal) {
		if (horizontal > 0 && facingRight || horizontal < 0 && !facingRight) {
			facingRight = !facingRight;
			transform.Rotate(0, 180, 0);
		}
	}

	private void HandleMovement() {
		Vector3 newVelocity = myRigidbody.velocity;
		if (isJumping) {
			newVelocity.y = jumpSpeed;
			isJumping = false;
		} 
		newVelocity.x = horizontalMovement * speed;
		myRigidbody.velocity = newVelocity;
		myAnimator.SetFloat("speed", Mathf.Abs(horizontalMovement));
		Flip(horizontalMovement);
	}

	private void SetCameraDistance () {
		Vector3 playerLocation = GetComponent<Transform>().position;
		Vector3 cameraLocation = mainCamera.transform.position;
		cameraDist = playerLocation - cameraLocation;
	}
}
