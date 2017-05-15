using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float jumpForce = 16f;
	public float runningSpeed = 1.8f;
	public LayerMask groundLayer;
	private Rigidbody2D rigidBody;
	public Animator animator;

	void Awake () {
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	void Start () {
		animator.SetBool ("isAlive", true);
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

	bool IsGrounded () {
		if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.2f, groundLayer.value)) {
			return true;
		} else {
			return false;
		}
	}
}
