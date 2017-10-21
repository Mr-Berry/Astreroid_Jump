using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour {

	public float speed;
	public float jumpSpeed;
	public float groundRadius;
	public Camera mainCamera;
	public Transform[] groundPoints;
	public ParticleSystem thrusters;
	public Slider Boosterbar;
	private float horizontalMovement;
	private Rigidbody myRigidbody;
	private Animator myAnimator;
	private bool facingRight = true;
	private bool isGrounded;
	private bool isJumping = false;
	private bool isFalling = false;
	private bool isBoosting = false;
	public LayerMask whatIsGround;
	private float boosterFuel = 1f;
	private float timer = 0f;

	// Use this for initialization
	void Start () {
		thrusters.Stop();
		myRigidbody = GetComponent<Rigidbody>();
		myAnimator = GetComponent<Animator>();
		Boosterbar.value = boosterFuel;
	}
	
	void Update () {
		timer += Time.deltaTime;
		if (isBoosting) {
			if (timer/0.05 >= 1) {
				boosterFuel -= 0.05f;
				timer = 0;
				Boosterbar.value = boosterFuel;
			}
		} else if (boosterFuel < 1) {
			if (timer/0.1 >= 1) {
				boosterFuel += 0.02f;
				timer = 0;
				Boosterbar.value = boosterFuel;
			}
		}
		handleInput();
	}
	// Update is called once per frame
	void FixedUpdate () {
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
		isGrounded = IsGrounded();
		Vector3 newVelocity = myRigidbody.velocity;
		if (isJumping && isGrounded) {
			newVelocity.y = jumpSpeed;
			isGrounded = false;
			myAnimator.SetBool("isJumping", true);
		} else if (isBoosting) {
			if (boosterFuel > 0) {
				newVelocity.y += 0.8f;
			} else {
				isBoosting = false;
				thrusters.Stop();
			}
		} else if (!isGrounded && myRigidbody.velocity.y <= 0 && !isBoosting) {
			isFalling = true;
			myAnimator.SetBool("isBoosting", false);
			myAnimator.SetBool("isJumping", false);
			myAnimator.SetBool("isFalling", true);
			thrusters.Stop();
		}
		newVelocity.x = horizontalMovement * speed;
		myRigidbody.velocity = newVelocity;
		myAnimator.SetFloat("speed", Mathf.Abs(horizontalMovement));
		Flip(horizontalMovement);
	}

	private bool IsGrounded () {
		bool retval = false;
		if (myRigidbody.velocity.y <= 0) {
			foreach (Transform point in groundPoints) {
				Collider[] colliders = Physics.OverlapSphere(point.position, groundRadius, whatIsGround);
				for (int i = 0; i < colliders.Length; i++) {
					if (colliders[i].gameObject != gameObject && colliders[i].gameObject.GetComponent<Pickup_Score>() == null) {
						myAnimator.SetBool("isFalling", false);
						myAnimator.SetBool("isBoosting", false);
						isFalling = false;
						isBoosting = false;
						retval = true;
						break;
					}
				}
			}
		}
		return retval;
	}

	private void handleInput () {
		horizontalMovement = Input.GetAxis("Horizontal");
		if (Input.GetAxis("Jump") > 0 && isGrounded) {
			isJumping = true;
		}
		if (Input.GetAxis("Jump") == 0 && isJumping) {
			isJumping = false;
		}
		if (Input.GetAxis("Jump") > 0 && !isGrounded && boosterFuel > 0 && !isBoosting && !isJumping) {
			myAnimator.SetBool("isBoosting", true);
			myAnimator.SetBool("isJumping", false);
			myAnimator.SetBool("isFalling", false);
			isFalling = false;
			isBoosting = true;
			thrusters.Play();
		}
		if (Input.GetAxis("Jump") == 0 && isBoosting) {
			isBoosting = false;
			thrusters.Stop();
		}
	}

	public void InceaseSpeed () {
		speed *= 1.01f;
	}
}
