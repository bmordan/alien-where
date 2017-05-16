using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static PlayerController instance;

	public Animator animator;

	public LayerMask groundLayer;
	private float jumpForce;
	private float runningSpeed;
	public Vector3 startingPosition;
	private Rigidbody2D rigidBody;

	void Awake() {
		instance = this;
		startingPosition = this.transform.position;
		rigidBody = GetComponent<Rigidbody2D>();
		jumpForce = 22;
		runningSpeed = 8;
	}


	public void StartGame() {
		rigidBody.gravityScale = 2.7f;
		rigidBody.velocity = new Vector2 (0, 0);
		animator.SetBool("isAlive", true);			
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
		this.transform.position = startingPosition;
		rigidBody.velocity = new Vector2 (0, 0);
		rigidBody.gravityScale = 0;
	}
}
	