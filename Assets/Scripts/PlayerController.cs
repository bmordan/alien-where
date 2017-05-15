using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float jumpForce = 16f;
	public LayerMask groundLayer;
	private Rigidbody2D rigidBody;

	void Awake () {
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		if (Input.GetButtonDown ("Jump"))
			Jump ();
	}

	void Jump () {
		if (IsGrounded())
		    rigidBody.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
	}

	bool IsGrounded () {
		if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.2f, groundLayer.value)) {
			return true;
		} else {
			return false;
		}
	}
}
