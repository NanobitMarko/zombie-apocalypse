using UnityEngine;
using System.Collections;

public class HumanController : HumanoidController {

	public int ScoreGiven = 10;

	private void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag != "Level Tile") {
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
		var dust = Instantiate (Resources.Load<Transform> ("Prefabs/DustSprite"));
		dust.transform.position = transform.position;
		Destroy (this.gameObject);
		Destroy (dust.gameObject, dust.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length); 
		Destroy (particle.gameObject, particle.GetComponent<ParticleSystem>().duration); 
	}

	private void killMe () {
		//		Debug.Log ("Triggered die");
		Destroy (this.gameObject);
	}
}
