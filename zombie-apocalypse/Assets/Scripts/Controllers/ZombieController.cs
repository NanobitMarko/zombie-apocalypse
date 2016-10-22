using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ZombieController : HumanoidController {

	public int JumpingPower = 11;

	public ZombieState State;

	public void Awake () {
		State = new ZombieState ();
		Invoke ("TickEnergy", State.EnergyDrainPeriod);
	}

	public void Jump (PointerEventData eventData) {
		if (grounded && !dead) {
			rb.AddForce (Vector2.up * JumpingPower, ForceMode2D.Impulse);
			animator.SetBool ("Grounded", false);
			grounded = false;
		}
	}

	private void OnCollisionEnter2D (Collision2D collision) {
		if (collision.collider.transform.position.y < transform.position.y && Mathf.Abs (collision.collider.transform.position.x - transform.position.x) < 1.5f /* khm khm*/ && collision.gameObject.tag == "Level Tile") {
			animator.SetBool ("Grounded", true);
			grounded = true;
			finishedJumpAnimation = false;
		}
		if (collision.collider.gameObject.tag == "Human") {
			HumanController human = collision.collider.GetComponent<HumanController>();
			if (human != null)
				human.SpecialEffect(this);
			Destroy (collision.collider.gameObject);
		}
		foreach (var contact in collision.contacts) {
			BoxCollider2D collider = GetComponent<BoxCollider2D> ();
			if (collider.bounds.Contains (contact.point)) {
				//				Debug.Log ("collided die"); else {
					base.Die ();
					break;
				}

				return;
		}
	}
	/* unused, maybe will be used if the box collider turns into a trigger collider*/
	private void OnTriggerEnter2D (Collider2D collider) {
		//		Debug.Log ("Triggered die");
		//base.Die ();
	}
	
	private void TickEnergy () {
		State.TickEnergy ();
		Invoke ("TickEnergy", State.EnergyDrainPeriod);
	}
}
