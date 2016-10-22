using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	[SerializeField]
	float xOffset = 6;

	private Transform player;
	private bool initialized = false;

	public void Initialize (Transform player) {
		this.player = player;
		initialized = true;
	}
		
	// Update is called once per frame
	void LateUpdate () {
		if (initialized)
			transform.position = new Vector3 (player.transform.position.x + xOffset, transform.position.y, transform.position.z);
	}
}
