using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	[SerializeField]
	private ZombieController zombiePrefab;

	[HideInInspector]
	public ZombieController Zombie;

	[SerializeField]
	private LevelGenerator generator;

	private LevelSegment endSegment;

	public static LevelManager Create () {
		return Instantiate (Resources.Load<LevelManager> ("Prefabs/Level Manager"));
	}

	public void CreateZombie () {
		Zombie = Instantiate (zombiePrefab);
		Zombie.transform.position = new Vector3 (1, 1, 0);
		Zombie.transform.SetParent (transform, false);
		GameManager.Instance.MenuManager.TouchController.PointerDown += Zombie.Jump;
		Camera.main.GetComponent<CameraFollow> ().Initialize (Zombie.transform);
	}


	void Update () {

		endSegment = generator.generateSegment (1);

	}
}
