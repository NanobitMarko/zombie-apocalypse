using UnityEngine;
using System.Collections;

public class HumanController : HumanoidController {

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
		Destroy (this.gameObject);
		Debug.Log ("NOM NOM");
	}
}
