using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	public Rigidbody2D rb;

	[SerializeField]
	public float movespeed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2(movespeed, rb.velocity.y);
	}
}
