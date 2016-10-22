using UnityEngine;
using System.Collections;

public class HumanController : HumanoidController {

	private void OnCollisionEnter2D (Collision2D collision) {
		if (collision.collider.transform.position.y < transform.position.y && Mathf.Abs (collision.collider.transform.position.x - transform.position.x) < 1.5f /* khm khm*/ && collision.gameObject.tag == "Level Tile") {
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
		Debug.Log("NOM NOM");
	}

	private void OnTriggerEnter2D (Collider2D collider) {
		//		Debug.Log ("Triggered die");
		base.Die ();
	}

}
