using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ZombieController : HumanoidController {

	public int JumpingPower = 11;

	private float StartX = 0;

	private float AdditionalScore = 0;

	public ZombieState State;

	public void Awake () {
		State = new ZombieState ();
		Invoke ("TickEnergy", State.EnergyDrainPeriod);
	}

	private void Start () {
		StartX = transform.position.x;
	}

	protected override void Update () {
		base.Update ();
		UpdateScore ();
	}

	private void UpdateScore () {
		if (!dead)
			State.Score = transform.position.x - StartX + AdditionalScore;
	}

	public void Jump (PointerEventData eventData) {
		if (grounded && !dead) {
			rb.AddForce (Vector2.up * JumpingPower, ForceMode2D.Impulse);
			animator.SetBool ("Grounded", false);
			grounded = false;
		}
	}

	private void OnCollisionEnter2D (Collision2D collision) {
		if (dead)
			return;

		if (collision.collider.transform.position.y < transform.position.y && Mathf.Abs (collision.collider.transform.position.x - transform.position.x) < 1.5f /* khm khm*/ && collision.gameObject.tag == "Level Tile") {
			animator.SetBool ("Grounded", true);
			grounded = true;
			finishedJumpAnimation = false;
		}
		if (collision.collider.gameObject.tag == "Human") {
			HumanController human = collision.collider.GetComponent<HumanController> ();
			if (human != null) {
				human.SpecialEffect (this);
				AdditionalScore += human.ScoreGiven;
				GameManager.Instance.SoundManager.PlaySoundEffect (SoundManager.ZombieKill);
			}
			return;
		}
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Obstacle")) {
			Die ();
			Destroy (collision.collider.gameObject);
			return;
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

	protected override void Die () {
		if (!dead) {
			CancelInvoke ("TickEnergy");
		}

		GameManager.Instance.SoundManager.PlaySoundEffect (SoundManager.ZombieDeath);
		base.Die ();
	}

	private void TickEnergy () {
		State.TickEnergy ();
		Invoke ("TickEnergy", State.EnergyDrainPeriod);
	}
}
