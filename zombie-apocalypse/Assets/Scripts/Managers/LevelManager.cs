using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	[SerializeField]
	public CharacterController zombie;

	public static LevelManager Create () {
		return Instantiate (Resources.Load<LevelManager> ("Prefabs/Level Manager"));
	}

	public void Initialize () {
		zombie.Initialize (GameManager.Instance.MenuManager.TouchController);
		Camera.main.GetComponent<CameraFollow> ().Initialize (zombie.transform);
	}


}
