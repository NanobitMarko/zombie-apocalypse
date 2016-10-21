using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	Transform player;
	bool initialized = false;

	public void Initialize (Transform player) {
		this.player = player;
		initialized = true;
	}
		
	// Update is called once per frame
	void LateUpdate () {
		if (initialized)
			transform.position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z);
	}
}
