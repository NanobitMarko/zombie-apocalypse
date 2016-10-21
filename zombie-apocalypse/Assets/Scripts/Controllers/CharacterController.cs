using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CharacterController : ObjectController {

	public Rigidbody2D rb;

	[SerializeField]
	public float movespeed;
	[SerializeField]
	protected Animator animator;

	protected bool grounded = true;

	protected bool finishedJumpAnimation = false;

	void Start () {
		rb.velocity = new Vector2 (movespeed, rb.velocity.y);
	}

	private void OnCollisionEnter2D (Collision2D collision) {
		if (finishedJumpAnimation && collision.gameObject.tag == "Level Tile") {
			animator.SetBool ("Grounded", true);
			grounded = true;
			finishedJumpAnimation = false;
		}
	}

	private void FinishedJumpAnimation () {
		finishedJumpAnimation = true;
	}
}
