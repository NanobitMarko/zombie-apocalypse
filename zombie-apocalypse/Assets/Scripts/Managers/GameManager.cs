using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	[HideInInspector]
	public MenuManager MenuManager;

	[HideInInspector]
	public LevelManager LevelManager;

	enum GameState {NOTSTARTED, STARTED, PAUSED, ENDED};
	public GameState CurrentGameState;


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
		CurrentGameState = GameState.NOTSTARTED;
	}
		
	public void StartGame () {
		CurrentGameState = GameState.STARTED;
		LevelManager.CreateZombie ();
	}

	private void PauseGame () {
		CurrentGameState = GameState.PAUSED;
		LevelManager.PauseLevel ();
	}

	private void ResumeGame () {
		CurrentGameState = GameState.STARTED;
		LevelManager.ResumeLevel ();
	}

	public GameState getCurrentGameState () {
		return CurrentGameState;
	}
}
