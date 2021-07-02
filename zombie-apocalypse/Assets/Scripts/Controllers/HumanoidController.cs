using UnityEngine;

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

	protected virtual void Update () {
		rb.velocity = new Vector2 (dead ? 0 : movespeed, rb.velocity.y);
		if (!dead && transform.position.y < -10) {
//			Debug.Log ("killbox die");
			Die ();
		}
	}

	private void FinishedJumpAnimation () {
		finishedJumpAnimation = true;
	}

	protected virtual void Die () {
		if (!dead) {
//			Debug.Log ("dieded");
			dead = true;
			animator.SetBool ("Killed", true);

			if (DeathTriggered != null)
				DeathTriggered (this);
		}
	}
}
