using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	[SerializeField]
	public CharacterController zombie;

	[SerializeField]
	private LevelGenerator generator;

	private LevelSegment endSegment;

	public static LevelManager Create () {
		return Instantiate (Resources.Load<LevelManager> ("Prefabs/Level Manager"));
	}

	public void Initialize () {
		zombie.Initialize (GameManager.Instance.MenuManager.TouchController);
		Camera.main.GetComponent<CameraFollow> ().Initialize (zombie.transform);

	}


	void Update() {

		endSegment = generator.generateSegment (1);

	}
}
