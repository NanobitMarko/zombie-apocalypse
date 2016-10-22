using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	[HideInInspector]
	public MenuManager MenuManager;

	[HideInInspector]
	public LevelManager LevelManager;

	public bool GameStarted = false;

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
		LevelManager.Initialize ();
		LevelManager.transform.SetParent (transform, false);
//		LevelManager.CreateZombie ();

		MenuManager.ShowMenu (MainMenu.Create ());
	}

	public void StartGame () {
		LevelManager.CreateZombie ();
		GameStarted = true;
	}

	private bool isPaused() {
		return LevelManager.IsLevelPaused ();
	}

	private void Pause () {
		LevelManager.PauseLevel ();
	}

	private void Resume () {
		LevelManager.ResumeLevel ();
	}

}
