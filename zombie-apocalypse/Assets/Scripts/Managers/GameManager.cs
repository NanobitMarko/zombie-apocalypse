using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	[HideInInspector]
	public MenuManager MenuManager;

	[HideInInspector]
	public LevelManager LevelManager;

	private void Start () {
		Initialize ();
	}

	private void Initialize () {
		if (Instance == null) {
			Instance = this;
		} else {
			Destroy (this.gameObject);
		}

		MenuManager = MenuManager.Create ();
		MenuManager.transform.SetParent (transform, false);
		LevelManager = LevelManager.Create ();
		LevelManager.transform.SetParent (transform, false);
		LevelManager.Initialize ();
	}

	public void StartGame () {
		
	}
}
