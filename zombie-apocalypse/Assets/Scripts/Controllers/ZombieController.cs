using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ZombieController : CharacterController {

	public int JumpingPower = 9;

	private int canJump;

	void Update () {
		rb.velocity = new Vector2 (movespeed, rb.velocity.y);
	}

	public void Jump (PointerEventData eventData) {
		if (grounded) {
			rb.AddForce (Vector2.up * JumpingPower, ForceMode2D.Impulse);
			animator.SetBool ("Grounded", false);
			grounded = false;
		}
	}
}
