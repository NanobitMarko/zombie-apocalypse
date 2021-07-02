using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ZombieController : HumanoidController {

	public int JumpingPower = 11;

	private float StartX = 0;

	private float AdditionalScore = 0;

	private bool blockAllMovement = false;

	public ZombieState State;
	private static readonly int GROUNDED = Animator.StringToHash("Grounded");

	public void Awake () {
		State = new ZombieState ();
		Invoke (nameof(TickEnergy), State.EnergyDrainPeriod);
	}

	private void Start () {
		StartX = transform.position.x;
	}

	protected override void Update () {
		if (!blockAllMovement)
			base.Update ();
		UpdateScore ();

		if (State.Energy <= 0)
			base.Die ();
	}

	private void UpdateScore () {
		if (!dead)
			State.Score = transform.position.x - StartX + AdditionalScore;
	}

	public void Jump (PointerEventData eventData) {
		if (grounded && !dead && !blockAllMovement) {
			rb.AddForce (Vector2.up * JumpingPower, ForceMode2D.Impulse);
			animator.SetBool (GROUNDED, false);
			grounded = false;
		}
	}

	private void OnCollisionEnter2D (Collision2D collision) {
		if (dead)
			return;

		if (collision.collider.transform.position.y < transform.position.y && Mathf.Abs (collision.collider.transform.position.x - transform.position.x) < 1.5f /* khm khm*/ && collision.gameObject.CompareTag("Level Tile")) {
			animator.SetBool (GROUNDED, true);
			grounded = true;
			finishedJumpAnimation = false;
		}
		if (collision.collider.gameObject.CompareTag("Human")) {
			HumanController human = collision.collider.GetComponent<HumanController> ();
			if (human != null) {
				human.SpecialEffect (this);
				AdditionalScore += human.ScoreGiven;
				GameManager.Instance.SoundManager.PlaySoundEffect (SoundManager.ZombieKill);
			}
			return;
		}
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Obstacle")) {
			Die ();
			Destroy (collision.collider.gameObject);
			return;
		}
		foreach (var contact in collision.contacts) {
			BoxCollider2D boxCollider = GetComponent<BoxCollider2D> ();
			if (boxCollider.bounds.Contains (contact.point)) {
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
			CancelInvoke (nameof(TickEnergy));
			GameManager.Instance.SoundManager.PlaySoundEffect (SoundManager.ZombieDeath);
		}

		base.Die ();
	}

	private void TickEnergy () {
		State.TickEnergy ();
		Invoke (nameof(TickEnergy), State.EnergyDrainPeriod);
	}

	public void SpawnStarted () {
		GameManager.Instance.MenuManager.ShowMenu (LightningFlash.Create ());
		rb.velocity = new Vector2 (0, rb.velocity.y);
		blockAllMovement = true;
	}

	public void SpawnEnded () {
		blockAllMovement = false;
	}
}
