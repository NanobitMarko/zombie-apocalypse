using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CharacterController : ObjectController {

	public Rigidbody2D rb;

	[SerializeField]
	public float movespeed;

	void Start () {
		rb.velocity = new Vector2 (movespeed, rb.velocity.y);
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "") {
			
		}
	}
}
