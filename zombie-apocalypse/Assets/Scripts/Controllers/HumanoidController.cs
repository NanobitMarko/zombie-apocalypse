using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class HumanoidController : ObjectController {

	public Rigidbody2D rb;

	[SerializeField]
	public float movespeed;
	[SerializeField]
	protected Animator animator;

	protected bool grounded = true;

	protected bool finishedJumpAnimation = true;

	protected bool dead = false;

	public delegate void DeathHandler (HumanoidController humanoid);

	public event DeathHandler DeathTriggered;

	private void Update () {
		rb.velocity = new Vector2 (dead ? 0 : movespeed, rb.velocity.y);
		if (!dead && transform.position.y < -10) {
//			Debug.Log ("killbox die");
			Die ();
		}
	}

	private void OnCollisionEnter2D (Collision2D collision) {
		if (collision.collider.transform.position.y < transform.position.y && Mathf.Abs (collision.collider.transform.position.x - transform.position.x) < 1.5f /* khm khm*/ && collision.gameObject.tag == "Level Tile") {
			animator.SetBool ("Grounded", true);
			grounded = true;
			finishedJumpAnimation = false;
		}
		foreach (var contact in collision.contacts) {
			BoxCollider2D collider = GetComponent<BoxCollider2D> ();
			if (collider.bounds.Contains (contact.point)) {
//				Debug.Log ("collided die");
				Die ();

				return;
			}
		}
	}
	/* unused, maybe will be used if the box collider turns into a trigger collider*/
	private void OnTriggerEnter2D (Collider2D collider) {
//		Debug.Log ("Triggered die");
		Die ();
	}

	private void FinishedJumpAnimation () {
		finishedJumpAnimation = true;
	}

	private void Die () {
		if (!dead) {
//			Debug.Log ("dieded");
			dead = true;
			animator.SetBool ("Killed", true);

			foreach (var collider in GetComponents<Collider2D>()) {
				collider.enabled = false;
			}

			if (DeathTriggered != null)
				DeathTriggered (this);
		}
	}
}
