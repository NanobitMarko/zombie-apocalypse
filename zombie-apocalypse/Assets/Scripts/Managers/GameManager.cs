using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	[HideInInspector]
	public MenuManager MenuManager;

	[HideInInspector]
	public LevelManager LevelManager;

	public enum GameState {NOTSTARTED, STARTED, PAUSED, ENDED};
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
		Time.timeScale = 0;
	}

	private void ResumeGame () {
		CurrentGameState = GameState.STARTED;
		Time.timeScale = 1;
	}

	public GameState GetCurrentGameState () {
		return this.CurrentGameState;
	}
}
