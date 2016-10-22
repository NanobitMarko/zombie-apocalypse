using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ZombieController : HumanoidController {

	public int JumpingPower = 11;

	public void Jump (PointerEventData eventData) {
		if (grounded && !dead) {
			rb.AddForce (Vector2.up * JumpingPower, ForceMode2D.Impulse);
			animator.SetBool ("Grounded", false);
			grounded = false;
		}
	}
}
