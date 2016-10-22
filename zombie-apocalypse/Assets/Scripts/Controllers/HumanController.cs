using UnityEngine;
using System.Collections;

public class HumanController : HumanoidController {

	private void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Level Tile") {
			animator.SetBool ("Grounded", true);
			grounded = true;
		}else {
			Physics2D.IgnoreCollision (collision.collider, GetComponent<Collider2D> ());
		}
	}
    //unused, maybe will be used if the box collider turns into a trigger collider
	public void SpecialEffect (ZombieController zombie) {
		//		Debug.Log ("Triggered die");
		//
		zombie.State.Energy += 0.2f * ZombieState.MaxEnergy;

		var particle = Instantiate (Resources.Load<ParticleSystem> ("Particles/BloodSplatter"));
		particle.transform.position = transform.position;
		Destroy (this.gameObject);
	}

	private void killMe () {
		//		Debug.Log ("Triggered die");
		Destroy (this.gameObject);
	}

	private void OnTriggerEnter2D (Collider2D collider) {
		//		Debug.Log ("Triggered die");
		base.Die ();
	}

}
