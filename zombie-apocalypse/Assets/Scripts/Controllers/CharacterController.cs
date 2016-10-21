using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CharacterController : ObjectController {

	public Rigidbody2D rb;

	[SerializeField]
	public float movespeed;

	public void Initialize (LevelTouchController inputController) {
		inputController.PointerDown += Jump;
	}

	void Start () {
		rb.velocity = new Vector2 (movespeed, rb.velocity.y);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Jump (PointerEventData eventData) {
		rb.AddForce (Vector2.one * 5, ForceMode2D.Impulse);
	}
}
