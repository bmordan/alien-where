﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static PlayerController instance;

	public float jumpForce;
	public float runningSpeed;
	public Animator animator;

	private Vector3 startingPosition;
	private Rigidbody2D rigidBody;

	void Awake() {
		instance = this;
		rigidBody = GetComponent<Rigidbody2D>();
		startingPosition = this.transform.position;
		jumpForce = 18;
		runningSpeed = 8;
	}


	public void StartGame() {
		animator.SetBool("isAlive", true);
		if (!isGrounded())
			this.transform.position = startingPosition;
	}

	void Update () {

		if (GameManager.instance.currentGameState == GameState.inGame) 
		{
			if (Input.GetButtonDown("Jump")) {
				Jump();
			}
			animator.SetBool("isGrounded", isGrounded());
		}
	}


	void FixedUpdate() {
		if (GameManager.instance.currentGameState == GameState.inGame) 
		{
			if (rigidBody.velocity.x < runningSpeed) {
				rigidBody.velocity = new Vector2(runningSpeed, rigidBody.velocity.y);
			}
		}
	}



	void Jump() {
		if (isGrounded()) {
			rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}

	public LayerMask groundLayer;

	bool isGrounded() {

		if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.2f, groundLayer.value)) {
			return true;
		}
		else {
			return false;
		}
	}



	public void Kill() {
		GameManager.instance.GameOver();
		animator.SetBool("isAlive", false);
		CameraFollow.instance.ResetToStartPosition ();
	}


}
	