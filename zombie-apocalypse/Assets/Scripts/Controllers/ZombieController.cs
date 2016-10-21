using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ZombieController : CharacterController {

	void Start () {
		rb.velocity = new Vector2 (movespeed, rb.velocity.y);
	}

	public void Jump (PointerEventData eventData) {
		rb.AddForce (Vector2.up * 5, ForceMode2D.Impulse);
	}
}
