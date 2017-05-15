using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public static PlayerController instance;
	public float jumpForce = 16f;
	public float runningSpeed = 1.8f;
	public LayerMask groundLayer;
	public Animator animator;
	private Rigidbody2D rigidBody;
	private Vector3 playerStartingPosition;


	void Awake () {
		instance = this;
		rigidBody = GetComponent<Rigidbody2D> ();
		playerStartingPosition = this.transform.position;
	}

	public void StartGame () {
		animator.SetBool ("isAlive", true);
		this.transform.position = playerStartingPosition;
	}

	void FixedUpdate () {
		if (GameManager.instance.currentGameState == GameState.inGame) {
			if (rigidBody.velocity.x < runningSpeed)
				rigidBody.velocity = new Vector2 (runningSpeed, rigidBody.velocity.y);
		}
	}

	void Update () {
		if (Input.GetButtonDown ("Jump"))
			Jump ();
		animator.SetBool ("isGrounded", IsGrounded ());
	}

	void Jump () {
		if (GameManager.instance.currentGameState == GameState.inGame) {
			if (IsGrounded())
				rigidBody.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}

	public void Kill () {
		GameManager.instance.GameOver ();
		animator.SetBool ("isAlive", false);
	}

	bool IsGrounded () {
		if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.2f, groundLayer.value)) {
			return true;
		} else {
			return false;
		}
	}
}
