using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	[SerializeField]
	float cameraOffsetFromCenter;

	private Transform player;
	private bool initialized = false;

	public void Initialize (Transform player) {
		this.player = player;
		initialized = true;
	}
		
	// Update is called once per frame
	void LateUpdate () {
		float unitWidth = Screen.width * Camera.main.orthographicSize * 2.0f / Screen.height;
		float offset = unitWidth * cameraOffsetFromCenter;
		if (initialized)
			transform.position = new Vector3 (player.transform.position.x - unitWidth*cameraOffsetFromCenter, transform.position.y, transform.position.z);
	}
}
