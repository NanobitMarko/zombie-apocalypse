using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class CityParallaxController : MonoBehaviour {

	[SerializeField]
	public float percentageOfZombieSpeed = 0.8f;

	private List<SpriteRenderer> backgroundParts;

	private Rigidbody2D rb;


	private bool spawned = false;

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

		backgroundParts = backgroundParts.OrderBy (t => t.transform.position.x).ToList ();

	}

	// Update is called once per frame
	void Update () {
		Vector3 velocity = new Vector3 (-5, 0, 0);

		if(!(GameManager.Instance.LevelManager.Zombie == null)) 
			velocity = new Vector3 (GameManager.Instance.LevelManager.Zombie.rb.velocity.x * percentageOfZombieSpeed, 0);

		rb.velocity = velocity;

		// Get the first object.
		// The list is ordered from left (x position) to right.
		SpriteRenderer firstChild = backgroundParts.FirstOrDefault ();

		if (firstChild != null) {
			if (firstChild.transform.position.x < Camera.main.transform.position.x) {
				if (firstChild.IsVisibleFrom (Camera.main) == false) {

					if (GameManager.Instance.CurrentGameState == GameManager.GameState.NOTSTARTED)
						handleNotStarted (firstChild);
					else if (!spawned && GameManager.Instance.CurrentGameState == GameManager.GameState.STARTED) {
						handleGonnaSpawn (firstChild);
					}
					else {
						handleNormal (firstChild);
					}

				}
			}
		}
	}

	void handleNormal(SpriteRenderer firstChild) {
		SpriteRenderer lastChild = backgroundParts.LastOrDefault ();

		Vector3 lastPosition = lastChild.transform.position;
		Vector3 lastSize = (lastChild.bounds.max - lastChild.bounds.min);

		firstChild.transform.position = new Vector3 (lastPosition.x + lastSize.x, firstChild.transform.position.y, firstChild.transform.position.z);

		backgroundParts.Remove (firstChild);

		if ((firstChild.sprite.name.Contains ("groblje") || firstChild.sprite.name.Contains ("billboard"))) {
			firstChild.transform.position = new Vector3 (0, -100);
		}
		else {
			backgroundParts.Add (firstChild);
		}
	}

	void handleGonnaSpawn(SpriteRenderer firstChild) {
		
		SpriteRenderer secondChild = backgroundParts[1];

		Vector3 lastPosition = secondChild.transform.position;
		Vector3 lastSize = (secondChild.bounds.max - secondChild.bounds.min);

		firstChild.transform.position = new Vector3 (0, -100);

		backgroundParts.Remove (firstChild);

		spawned = true;
	}

	void handleNotStarted(SpriteRenderer firstChild) {
		// insert first child on second place

		SpriteRenderer secondChild = backgroundParts[1];

		Vector3 lastPosition = secondChild.transform.position;
		Vector3 lastSize = (secondChild.bounds.max - secondChild.bounds.min);

		firstChild.transform.position = new Vector3 (lastPosition.x + lastSize.x, firstChild.transform.position.y, firstChild.transform.position.z);

		backgroundParts.Remove (firstChild);
		backgroundParts.Insert (1, firstChild);

		// move rest of the stuff
		for (int i = 2; i < backgroundParts.Count; i++) {
			SpriteRenderer sr = backgroundParts [i];
			sr.transform.position += new Vector3 (lastSize.x, 0, 0);
		}
	}
}
