using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ParallaxController : MonoBehaviour {

	[SerializeField]
	public float percentageOfZombieSpeed = 0.8f;

	private List<SpriteRenderer> backgroundParts;


	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		backgroundParts = new List<SpriteRenderer> ();

		for (int i = 0; i < transform.childCount; i++) {
			Transform c = transform.GetChild (i);
			SpriteRenderer r = c.GetComponent<SpriteRenderer> ();

			if (r != null) {
				backgroundParts.Add (r);
			}
		}

		backgroundParts = backgroundParts.OrderBy (t => transform.position.x).ToList ();
	}

	// Update is called once per frame
	void Update () {
		if (! (GameManager.Instance.CurrentGameState == GameManager.GameState.STARTED))
			return;
		
		Vector3 velocity = new Vector3 (GameManager.Instance.LevelManager.Zombie.rb.velocity.x * percentageOfZombieSpeed, 0);
		rb.velocity = velocity;

		// Get the first object.
		// The list is ordered from left (x position) to right.
		SpriteRenderer firstChild = backgroundParts.FirstOrDefault ();

		if (firstChild != null) {
			// Check if the child is already (partly) before the camera.
			// We test the position first because the IsVisibleFrom
			// method is a bit heavier to execute.
			if (firstChild.transform.position.x < Camera.main.transform.position.x) {
				// If the child is already on the left of the camera,
				// we test if it's completely outside and needs to be
				// recycled.
				if (firstChild.IsVisibleFrom (Camera.main) == false) {
					// Get the last child position.
					SpriteRenderer lastChild = backgroundParts.LastOrDefault ();

					Vector3 lastPosition = lastChild.transform.position;
					Vector3 lastSize = (lastChild.bounds.max - lastChild.bounds.min);

					// Set the position of the recyled one to be AFTER
					// the last child.
					// Note: Only work for horizontal scrolling currently.
					firstChild.transform.position = new Vector3 (lastPosition.x + lastSize.x, firstChild.transform.position.y, firstChild.transform.position.z);

					// Set the recycled child to the last position
					// of the backgroundPart list.
					backgroundParts.Remove (firstChild);
					backgroundParts.Add (firstChild);
				}
			}

		}

	}
}
